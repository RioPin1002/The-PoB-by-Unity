import sounddevice as sd
import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
import socket

# UDPクライアントの設定
HOST = '127.0.0.1'  # 送信先のホストアドレス（Unity側）
PORT = 50007  # 送信先のポート番号（Unity側）
client = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

# デバイスリストを取得して表示
device_list = sd.query_devices()
print(device_list)

# 入力・出力デバイスを設定（[2, 3] は適切なデバイスインデックスに置き換えてください）
sd.default.device = [2, 3]  # 入力デバイス、出力デバイス

# 最新の音声データを保持する変数
latest_data = [0]
count = 0
trigger = False

def callback(indata, frames, time, status):
    global latest_data
    # 入力データを取得
    data = indata[:, 0]
    # 最新のデータを更新
    latest_data[0] = data[-1]

def update_plot(frame):
    global latest_data, count, trigger
    # 最新のデータのみを更新
    line.set_ydata(latest_data)
    if latest_data[0] < -0.005 or 0.005 < latest_data[0]:
        if not trigger:
            print("detect", count)
            trigger = True
            count += 1
            # 検出されたときにUnityにUDPメッセージを送信
            client.sendto(b'1', (HOST, PORT))
    else:
        trigger = False
    return line,

# プロットの設定
fig, ax = plt.subplots()
line, = ax.plot([0], [0], 'bo')  # x軸は固定の0、y軸は初期値0
ax.set_ylim([-1.0, 1.0])  # y軸の範囲を設定
ax.set_xlim([-1, 1])  # x軸の範囲を設定（固定）

# グリッドを追加
ax.yaxis.grid(True)
fig.tight_layout()

# サウンドストリームを設定
stream = sd.InputStream(
    channels=1,
    dtype='float32',
    callback=callback
)

# アニメーションを設定
ani = FuncAnimation(fig, update_plot, interval=30, blit=True)

# ストリームを開始し、プロットを表示
with stream:
    plt.show()
