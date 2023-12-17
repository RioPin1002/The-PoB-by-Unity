import numpy as np
import matplotlib.pyplot as plt
from scipy.fft import fft
import serial
from datetime import datetime
import time

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

ser = serial.Serial(arduino_port, sampling_rate)
count = 0
error = 0
ArrayMax = 50
meanArray = [ArrayMax]
FilteredArray = []
timestamps = []



def ConvertFloat():
    try:
        num = float(ser.readline().decode('utf-8').strip())
    except:
        num = 0

    return num

startTime = datetime.now()

while (datetime.now() - startTime).seconds < 1:
    print(ConvertFloat())

startTime = datetime.now()
print("start")

while (datetime.now() - startTime).seconds < 5:
    if len(meanArray) < ArrayMax:
        meanArray.append(ConvertFloat())
    else:
        FilteredArray.append(np.mean(meanArray))
        timestamps.append(datetime.now())
        meanArray[:ArrayMax - 1] = meanArray[1:]
        meanArray[ArrayMax - 1] = ConvertFloat()

plt.plot(timestamps, FilteredArray)
plt.show()



    



ser.close()