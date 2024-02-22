import keyboard
import socket

HOST = '127.0.0.1'
PORT = 50007

# ソケットを作成
cliant = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)



# キーボードからの入力を監視し、対応するUDPメッセージを送信する
while True:
    sendText = "0"
    sendNum = 0



    if keyboard.is_pressed('up'):
        sendNum += 1000
    elif keyboard.is_pressed('down'):
        sendNum += 100
    elif keyboard.is_pressed('right'):
        sendNum += 10
    elif keyboard.is_pressed('left'):
        sendNum += 1

    sendText = str(sendNum)

    cliant.sendto(sendText.encode('utf-8'), (HOST, PORT))
    print(sendNum)

# プログラム終了時にはソケットを閉じる
cliant.close()