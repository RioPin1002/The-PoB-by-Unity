import socket
import random
import time

HOST = '127.0.0.1'  # 送信先のホストアドレス（ローカルホスト）
PORT = 50007  # 送信先のポート番号

client = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
while True:
    a = random.randint(1, 9)  # 1から9のランダムな数字を生成
    result = str(a)
    print(a)
    client.sendto(result.encode('utf-8'), (HOST, PORT))  # UDPでデータを送信
    time.sleep(2.0)  # 2秒待機