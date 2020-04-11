using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace PuzzlesGame
{
    public class PuzzlesManager : MonoBehaviour
    {
        AudioSource _mMyAudioSource;
        public GameObject[] puzzle = new GameObject[9];
        private int[,] position = {{0, 0, 0}, {0, 0, 0}, {0, 0, 0}};
        //конец движения
        public Transform  endPosition;
        public float speed;
    
        //передача ID в fixedUpdate
        private int _thisPuzzleId;
        private bool _goRightNow;
        public float positionDifference=2.3f;
         public TMP_Text iqtext;
        private int _iq=300;
         public bool autoWin;
        public GameObject winVideo;
        private void Start()
        {
            _mMyAudioSource = GetComponent<AudioSource>();
            GeneratePuzzle();
        }

        private void FixedUpdate()
        {
            if (_goRightNow)
            {
                puzzle[_thisPuzzleId].transform.position = Vector2.Lerp(puzzle[_thisPuzzleId].transform.position, endPosition.position, speed);
            }
        }

        public void OnPuzzleClick(int id)
        {
            _iq--;
            iqtext.text = "Ваш IQ= " + _iq.ToString();
            _mMyAudioSource.Play();
            int x = 0, y = 0;
            //Найдем позицию по ID
            for (int i = 0; i < 9; i++)
            {
                //перебираем координаты для матрциы
                if (y == 3)
                {
                    x++;
                    y = 0;
                }

                if (position[x, y] == id)
                {
                    break;
                }

                y++;
            }
            // запоммнает позицию
            // Визуализация проверки нажатого пазла
            //          |check|
            // |check| |Click|  |check|
            //         |check|
            //Если пустая клетка нашлась среди check, то переместить туда клетку
            //
            //если не выходит за рамки
            if (x - 1 >= 0)
            {
                //и если клетка пуста
                if (position[x - 1, y] == 0)
                {
                    position[x, y] = 0;
                    TransromPuzzle(x-1,y,id);
                }
            }

            if (x +1<= 2)
            {
                if (position[x + 1, y] == 0)
                {
                    //ставит пустую клетку на место пазла
                    position[x, y] = 0;
                    TransromPuzzle(x+1,y,id);
                }
            }
            if (y-1 >= 0)
            {
                if (position[x, y - 1] == 0)
                {
                    position[x, y] = 0;
                    TransromPuzzle(x,y-1,id);
                }
            }
            if (y+1<=2)
            {
                if (position[x, y +1 ] == 0)
                {
                
                    position[x, y] = 0;
                    TransromPuzzle(x,y+1,id);
                
                }
            }
        }
        private void TransromPuzzle(int x, int y,int ID)
        {
            //передаем id  в update
            _thisPuzzleId = ID;
            endPosition.position = new Vector2(RealPosition(x), RealPosition(y));
            //ставим пазл на пустую клетку
            position[x, y] = ID;
            //задаем конец перемещения
            //разрешаем сейчас использовать
            _goRightNow = true;
            //проверяем, решили ли мы правильно 
            CheckPuzzle();
        }
        private void CheckPuzzle()
        {
            int buff = 0, x = 0, y = 0;
            //правильная комбинация для выйгрыша
            // незнаю почему такая)))
            int[] adress = {6,3,0,7,4,1,8,5,2};
            for (int i = 0; i < 9; i++)
            {
                //перебираем координаты для матрциы
                if (y == 3)
                {
                    x++;
                    y = 0;
                }
            
                if (position[x, y] == adress[i])
                {
                    buff++;
                }
                y++;
            }
            if (buff==9) {
                winVideo.SetActive(true);
                Invoke("LoadGameScene",5);
            }
        }

        private void LoadGameScene()
        {
            
            Statics.level=2;
            Debug.Log("Победа, загрузка сцены Game...");
            Debug.Log("Уровень сейчас "+ Statics.level);
            
            SceneManager.LoadScene("Game");
        }
 
    
        private void GeneratePuzzle()
        {
            //правильная комбинация для выйграша
            int[] adress = {2, 5, 8,1, 4, 7,0, 3, 6};
       
            if (!autoWin)
            {
                //перемешка случайным образом массив adress
                Shuffle(adress);
            }

            for (int i = 0; i <= 8; i++)
            {
                PasteOnPosition(puzzle[i], adress[i], i);
            }
        }

        //вставляет на место по адресу 
        private void PasteOnPosition(GameObject puzzle, int adress, int id)
        {
            int x = 0, y = 0;
            for (int i = 0; i <= 9; i++)
            {
                if (y == 3)
                {
                    x++; 
                    y = 0;
                }
                //находи место для puzzle
                if (adress == i)
                {
                    puzzle.transform.position=new Vector2(RealPosition(x),RealPosition(y));
                    position[x, y] = id;
                }
                y++;
            }
        
        }
        //переводит из id местоположение в игровое
        private float RealPosition(int x)
        {
            switch (x)
            {
                case 0:
                    return -positionDifference;
                case 1:
                    return  0;
                case 2:
                    return positionDifference;
                default:
                    return  0;
            }
        }
  
        //http://www.dotnetperls.com/fisher-yates-shuffle
        // перемешка  массива
        private void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            for (int i = 0; i < (n - 1); i++)
            {
                int r = i + Random.Range(0,n - i);
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }
    }
}
