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

detectHaleMode = False

cliant = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)


def ConvertFloat():
    try:
        num = float(ser.readline().decode('utf-8').strip())
    except:
        num = 0

    return num

def has_value_above_threshold(array, threshold):
    return any(element >= threshold for element in array)

startTime = datetime.now()

while (datetime.now() - startTime).seconds < 1:
    print(ConvertFloat())

startTime = datetime.now()
print("start")
while True:
    if len(meanArray) < ArrayMax:
        meanArray.append(ConvertFloat())
    else:
        addNum = ConvertFloat()
        addMean = np.mean(meanArray)
        meanArray[:ArrayMax - 1] = meanArray[1:]
        meanArray[ArrayMax - 1] = addNum
        
        if(addMean > 1950):
            detectHaleMode = True
        if(detectHaleMode == False):
            addDateTime = time.time()
        if(detectHaleMode == True):
            if(time.time() - addDateTime < 0.3):
                detectHaleArray.append(addMean)
            else:
                if has_value_above_threshold(detectHaleArray, 2200) == False:
                    cliant.sendto("1".encode('utf-8'),(HOST, PORT))
                    print("detectInhale")
                else:
                    cliant.sendto("2".encode('utf-8'),(HOST, PORT))
                    print("detectExhale")
                detectHaleMode = False
                detectHaleArray = []




    



ser.close()