import socket
import time
import random

HOST = '127.0.0.1'
PORT = 50007

client = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

while True:
    a = random.randrange(2)
    result = str(a)
    print(a)
    client.sendto(result.encode('utf-8'), (HOST, PORT))
    time.sleep(0.001)