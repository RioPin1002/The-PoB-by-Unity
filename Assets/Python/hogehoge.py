import serial
import matplotlib.pyplot as plt
from datetime import datetime, timedelta

# Arduinoとのシリアル通信の設定
arduino_port = '/dev/cu.usbserial-0001'  # Arduinoが接続されているポートに変更してください
baud_rate = 230400
ser = serial.Serial(arduino_port, baud_rate)

# データを格納するためのリスト
timestamps = []
values = []

# 開始時間を取得
start_time = datetime.now()

try:
    while (datetime.now() - start_time).seconds < 1:
        # Arduinoからデータを読み取り
        raw_data = ser.readline().decode('utf-8').strip()
        sensor_value = int(raw_data)

        # 現在の時刻を取得
        current_time = datetime.now()

        # リストに時刻とデータを追加
        timestamps.append(current_time)
        values.append(sensor_value)

        # 経過時間をターミナルに表示
        elapsed_time = current_time - start_time
        print(f"Elapsed Time: {elapsed_time.seconds} seconds", end='\r')

except KeyboardInterrupt:
    pass

finally:
    # グラフをプロット
    plt.plot(timestamps, values)
    plt.xlabel('Time')
    plt.ylabel('Sensor Value')
    plt.show()

    # シリアル通信をクローズ
    ser.close()
    print("\nSerial communication closed.")
