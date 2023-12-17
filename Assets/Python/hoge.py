import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation
import serial
from datetime import datetime

ser = serial.Serial('/dev/cu.usbserial-0001', 230400)

fig = plt.figure()


max = 1024
x_array = [max]
y_array = [max]

while len(x_array) != max:
    y_array.append(float(ser.readline().decode('utf-8').strip()))
    x_array.append(datetime.now())

def plot(data):
    plt.cla()                      # 現在描写されているグラフを消去
    addValue = float(ser.readline().decode('utf-8').strip())
    y_array[:-1] = y_array[1:]
    y_array[-1] = addValue
    x_array[:-1] = x_array[1:]
    x_array[-1] = datetime.now()
    plt.plot(x_array, y_array)            # グラフを生成

ani = animation.FuncAnimation(fig, plot, interval=1)
plt.show()
ser.close()