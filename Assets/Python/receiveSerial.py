import numpy as np
import matplotlib.pyplot as plt
from scipy.fft import fft
import serial
from datetime import datetime
import time
import socket

# Arduinoのシリアルポートを指定
arduino_port = '/dev/cu.usbserial-0001'  # あなたのArduinoのポートに変更してください

# Arduinoからのサンプリングレートとサンプル数
sampling_rate = 230400  # Arduinoで設定したサンプリングレートに合わせてください
num_samples = 1024    # フーリエ変換のためのサンプル数
haleStartTime = 0
haleEndTime = 0
haleSample = []
haleTrigger = False
haleCoTrigger = False

HOST = '127.0.0.1'
PORT = 50007

ser = serial.Serial(arduino_port, sampling_rate)
count = 0
error = 0
ArrayMax = 50
meanArray = [ArrayMax]
FilteredArray = []
timestamps = []
detectHaleArray = []
receiveToUnityToken = 0

timelag = False

detectHaleMode = False

cliant = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)


def ConvertFloat():
    try:
        num = float(ser.readline().decode('utf-8').strip())
    except:
        num = 0

    return num

def find_difference(arr):
    if not arr:
        # 配列が空の場合はエラー処理や適切なデフォルト値の返却などを考慮することが重要です。
        return None

    # 最大値と最小値を初期化
    max_value = arr[0]
    min_value = arr[0]

    # 配列を走査して最大値と最小値を更新
    for num in arr:
        if num > max_value:
            max_value = num
        elif num < min_value:
            min_value = num

    # 差を計算して返す
    return max_value - min_value

startTime = datetime.now()

while (datetime.now() - startTime).seconds < 1:
    print(ConvertFloat())

startTime = time.time()
print("start")
counter = 0
while True:
    addNum = ConvertFloat()

   
    

    if((addNum > 2200) & (timelag == False)):
        if(detectHaleMode == False):
            detectHaleMode = True
            haleStartTime = time.time()
            
            detectHaleArray.append(addNum)
            

    if((detectHaleMode == True) & (timelag == False)):
        detectHaleArray.append(addNum)
        if(time.time() - haleStartTime > 0.1):
            if(find_difference(detectHaleArray) > 2000):
                cliant.sendto("1".encode('utf-8'),(HOST, PORT))
                print(counter)
                counter += 1
                timelagtime = time.time()
                timelag = True
            detectHaleMode = False
            
    
    if(timelag == True):
        if(time.time() - timelagtime > 0.15):
            timelag = False

    



ser.close()