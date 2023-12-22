import serial
import time

# シリアルポートの設定
serial_port = '/dev/cu.usbserial-0001'  # または 'COMx' (Windows)
baud_rate = 230400

# シリアルポートを開く
ser = serial.Serial(serial_port, baud_rate, timeout=1)

endtime = 0
startime = time.time()
dataarray = []
try:
    while endtime - startime < 1:
        # シリアルポートからデータを読み取り、プリント
        data = ser.readline().decode('utf-8').strip()
        dataarray.append(data)
        # 適宜遅延を入れる
        endtime = time.time()

except KeyboardInterrupt:
    # Ctrl+Cが押されたら終了処理
    ser.close()
    print("Serial port closed.")

print(len(dataarray))
