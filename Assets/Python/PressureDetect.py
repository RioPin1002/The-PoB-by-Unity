import serial
import matplotlib.pyplot as plt
import numpy as np
from datetime import datetime, timedelta

# Arduinoのシリアルポートを指定してSerialオブジェクトを作成
ser = serial.Serial('/dev/cu.usbserial-0001', 9600)  # COM3はArduinoの接続されているシリアルポートに置き換える

# データを格納するリスト
time_values = []
pressure_diff_values = []
temperature_values = []

try:
    # 15秒間のデータを取得
    start_time = datetime.now()
    end_time = start_time + timedelta(seconds=15)
    
    while datetime.now() < end_time:
        # Arduinoからデータを読み取る
        data = ser.readline().decode().strip().split(',')
        if len(data) == 2:
            temperature, pressure_diff = map(float, data)
            print(f'Temperature: {temperature} °C, Pressure Difference: {pressure_diff} Pa')
            
            # 現在の時刻を取得してリストに追加
            current_time = datetime.now()
            time_values.append(current_time)
            pressure_diff_values.append(pressure_diff)
            temperature_values.append(temperature)

    # 平均移動法を使ってデータを平滑化
    window_size = 3
    smoothed_pressure_diff = np.convolve(pressure_diff_values, np.ones(window_size)/window_size, mode='valid')
    smoothed_temperature = np.convolve(temperature_values, np.ones(window_size)/window_size, mode='valid')
    smoothed_time_values = time_values[:len(smoothed_pressure_diff)]  # 平滑化後のデータに合わせて時間軸を調整

    # 微分してグラフの傾きを求める
    diff_pressure_diff = np.diff(smoothed_pressure_diff)
    diff_temperature = np.diff(smoothed_temperature)
    diff_time_values = smoothed_time_values[:-1]  # 時間軸を平滑化後のデータに合わせる

    # グラフの描画
    fig, axs = plt.subplots(4, 1, figsize=(10, 10))

    axs[0].plot(time_values, pressure_diff_values, label='Raw Pressure Difference', color='red')
    axs[0].set_xlabel('Time')
    axs[0].set_ylabel('Pressure Difference (Pa)')
    axs[0].set_title('Raw Pressure Difference over 15 Seconds')
    axs[0].legend()

    axs[1].plot(smoothed_time_values, smoothed_pressure_diff, label=f'Smoothed Pressure Difference (window size={window_size})', color='red')
    axs[1].set_xlabel('Time')
    axs[1].set_ylabel('Pressure Difference (Pa)')
    axs[1].set_title('Smoothed Pressure Difference over 15 Seconds')
    axs[1].legend()

    axs[2].plot(diff_time_values, diff_pressure_diff, label='Gradient of Pressure Difference', color='red')
    axs[2].set_xlabel('Time')
    axs[2].set_ylabel('Gradient')
    axs[2].set_title('Gradient of Pressure Difference over 15 Seconds')
    axs[2].legend()

    axs[3].plot(time_values, temperature_values, label='Temperature', color='blue')
    axs[3].set_xlabel('Time')
    axs[3].set_ylabel('Temperature (°C)')
    axs[3].set_title('Temperature over 15 Seconds')
    axs[3].legend()

    plt.tight_layout()
    plt.show()

except KeyboardInterrupt:
    print('Interrupted')
    ser.close()
