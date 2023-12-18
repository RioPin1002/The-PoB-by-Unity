import serial
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
from datetime import datetime

# シリアルポートの設定
ser = serial.Serial('/dev/cu.ESP32_BT', 115200)  # 'COM1' は使用するポートに変更してください
ser.flush()

# グラフの初期化
fig, ax = plt.subplots()
x_data, y_data = [], []
line, = ax.plot([], [], lw=2)

# グラフの初期化関数
def init():
    line.set_data([], [])
    return line,

# グラフの更新関数
def update(frame):
    try:
        # シリアル通信からデータを読み込み
        line_str = ser.readline().decode('utf-8')
        value = float(line_str)

        # データを追加し、グラフを更新
        x_data.append(datetime.now())
        y_data.append(value)
        line.set_data(x_data, y_data)

        # X軸の表示範囲を調整（必要に応じて変更）
        ax.set_xlim(x_data[0], x_data[-1])
        
        return line,
    except ValueError:
        pass

# アニメーションの作成
ani = FuncAnimation(fig, update, init_func=init, blit=True)

# 10秒間だけ実行する
plt.show(block=False)
plt.pause(10)

# シリアルポートを閉じる
ser.close()

#/dev/cu.usbserial-0001