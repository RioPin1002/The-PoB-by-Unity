import sounddevice as sd
import numpy as np
from matplotlib.animation import FuncAnimation
import matplotlib.pyplot as plt
from scipy import signal
from scipy.spatial.distance import euclidean
from fastdtw import fastdtw

device_list = sd.query_devices()
print(device_list)

sd.default.device = [1, 3]  # Input, Outputデバイス指定

prevAmpSet = None  # prevAmpSet変数をグローバルに宣言

BreathTrigger = False

count = 0

def callback(indata, frames, time, status):
    global plotdata, prevAmpSet  # prevAmpSet変数をグローバルに使用するために追加
    # indata.shape=(n_samples, n_channels)
    data = indata[::downsample, 0]
    shift = len(data)
    plotdata = np.roll(plotdata, -shift, axis=0)
    plotdata[-shift:] = data
    
    # 0.01秒前のアンプ値を取得
    prevAmpSet = nowAmpSet

def update_plot(frame):
    """This is called by matplotlib for each plot update."""
    global plotdata, window, nowAmpSet, prevAmpSet, BreathTrigger, count
    x = plotdata[-N:] * window
    F = np.fft.fft(x)  # フーリエ変換
    F = F / (N / 2)  # フーリエ変換の結果を正規化
    F = F * (N / sum(window))  # 窓関数による補正
    Amp = np.abs(F)  # 振幅スペクトル


    # プロット更新
    line.set_ydata(Amp[:N // 2])
    
    if BreathTrigger == False:
        if Amp[500] * 1000 > 0.03:
            count += 1
            print("呼吸検知", count)
            BreathTrigger = True
    else:
        if Amp[500] * 1000 < 0.03:
            BreathTrigger = False

    return line,

downsample = 1  # FFTするのでダウンサンプリングはしない
length = int(1000 * 44100 / (1000 * downsample))
plotdata = np.zeros((length))
N = 2048  # FFT用のサンプル数
fs = 44100  # 音声データのサンプリング周波数
window = signal.hann(N)  # 窓関数
freq = np.fft.fftfreq(N, d=1 / fs)  # 周波数スケール

fig, ax = plt.subplots()
line, = ax.plot(freq[:N // 2], np.zeros(N // 2))
ax.set_ylim([0, 0.2])
ax.set_xlim([0, 1000])
ax.set_xlabel('Frequency [Hz]')
ax.set_ylabel('Amplitude spectrum')
fig.tight_layout()

stream = sd.InputStream(
    channels=1,
    dtype='float32',
    callback=callback
)
ani = FuncAnimation(fig, update_plot, interval=30, blit=True)

nowAmpSet = None

with stream:
    plt.show()
