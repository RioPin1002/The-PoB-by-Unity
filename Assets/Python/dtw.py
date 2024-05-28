import numpy as np
import matplotlib.pyplot as plt


def main():
    #初期化
    waveA_x = [1, 2, 3, 4, 5, 6, 7] #比較対象A
    waveA_y = [1, 0, -1, -0.3, 0.1, 1.0, -1] #比較対象A
    waveB_x = [1, 2, 3, 4, 5, 6, 7, 8] #比較対象B
    waveB_y = [0, -0.5, -0.5, 0, 1.0, 1.0, -1.0, -1.2] #比較対象B

    #グラフ準備
    plt.ylim(-2, 2)
    plt.title("DTW TEST", fontsize = 24)
    plt.xlabel("waveA", fontsize=24)
    plt.ylabel("waveB", fontsize=24)
    plt.grid(True)

    dtw_2(waveA_x, waveA_y, waveB_x, waveB_y)





def dtw_2(waveA_x, waveA_y, waveB_x, waveB_y):

    #同じ波の中でのx,yの要素数が正しいか
    if len(waveA_x) != len(waveA_y):
        print("The number of waveA's X is not collect to that of Y")
        return False
    if len(waveB_x) != len(waveB_y):
        print("The number of waveB's X is not collect to that of Y")
        return False
    
    #全通りの距離の結果を格納するための配列
    all_distanse_matrix = np.zeros((len(waveA_x), len(waveB_x)), dtype=float)
    min_num_matrix = []


    #距離計算
    for a_index, a_num in enumerate(waveA_y):

        min_index = 0

        for b_index, b_num in enumerate(waveB_y):

            all_distanse_matrix[a_index][b_index] = np.abs(a_num - b_num)

            if b_index > 0:
                if all_distanse_matrix[a_index][b_index] > all_distanse_matrix[a_index][min_index]:
                    min_index = b_index


            if (a_index == 0) & (b_index > 0):
                all_distanse_matrix[a_index][b_index] += all_distanse_matrix[a_index][b_index - 1]
            elif (a_index > 0) & (b_index == 0):
                all_distanse_matrix[a_index][b_index] += all_distanse_matrix[a_index - 1][b_index]
            elif (a_index > 0) & (b_index > 0):
                all_distanse_matrix[a_index][b_index] += min(all_distanse_matrix[a_index - 1][b_index], all_distanse_matrix[a_index][b_index - 1], all_distanse_matrix[a_index - 1][b_index - 1])

        min_num_matrix.append(min_index)

    print(all_distanse_matrix)

    

    


    




if __name__ == '__main__':
    main()