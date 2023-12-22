import serial
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
from time import time

# グローバル変数
x_data = []
y_data = []

# シリアルポートの設定
ser = serial.Serial('/dev/cu.usbserial-0001', 230400)  # COM3は適切なポートに変更してください

# グラフの初期設定
fig, ax = plt.subplots()
line, = ax.plot([], [], lw=2)
ax.set_xlim(0, 10)  # x軸の範囲は適切に設定してください
ax.set_ylim(0, 5000)  # y軸の範囲は適切に設定してください

# データの更新関数
def update(frame):
    # シリアル通信からデータを読み込む
    data = ser.readline().decode('utf-8').rstrip()

    # 時刻を取得（任意の単位で時間を取得するために調整が必要）
    current_time = time()

    # データをリストに追加
    x_data.append(current_time)
    y_data.append(float(data))

    # グラフを更新
    line.set_data(x_data, y_data)

    return line,

# アニメーションの作成
# intervalで更新間隔を指定（ミリ秒単位）
ani = FuncAnimation(fig, update, blit=True, interval=100)

# グラフの表示
plt.show()
