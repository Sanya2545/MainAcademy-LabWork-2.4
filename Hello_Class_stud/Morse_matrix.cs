using System;
using System.Text;

namespace Hello_Class_stud
{
    //Implement class Morse_matrix derived from String_matrix, which realize IMorse_crypt
    class Morse_matrix : String_matrix, IMorse_crypt
    {
        public const int Size_2 = Alphabet.Size;
        private int offset_key = 0;


        //Implement Morse_matrix constructor with the int parameter for offset
        //Use fd(Alphabet.Dictionary_arr) and sd() methods
        public Morse_matrix(int offset = 0)
        {
            offset_key = offset;
            str_matrix = Alphabet.Dictionary_arr;
        }
        public Morse_matrix(string[,] dict_arr, int offset = 0)
        {
            str_matrix = dict_arr;
            offset_key = offset;
        }
        //Implement Morse_matrix constructor with the string [,] Dict_arr and int parameter for offset
        //Use fd(Dict_arr) and sd() methods


        private void fd(string[,] Dict_arr)
        {
            for (int ii = 0; ii < Size1; ii++)
                for (int jj = 0; jj < Size_2; jj++)
                    this[ii, jj] = Dict_arr[ii, jj];
        }


        private void sd()
        {
            int off = Size_2 - offset_key;
            for (int jj = 0; jj < off; jj++)
                this[1, jj] = this[1, jj + offset_key];
            for (int jj = off; jj < Size_2; jj++)
                this[1, jj] = this[1, jj - off];
        }

        //Implement Morse_matrix operator +

        public static Morse_matrix operator +(Morse_matrix morse_matrix1, Morse_matrix morse_matrix2)
        {
            if (morse_matrix1.str_matrix.Length == morse_matrix2.str_matrix.Length)
            {
                for (int i = 0; i < morse_matrix1.str_matrix.GetLength(0); ++i)
                {
                    for (int j = 0; j < morse_matrix2.str_matrix.GetLength(1); ++j)
                    {
                        morse_matrix1.str_matrix[i, j] += morse_matrix2.str_matrix[i, j];
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Matrixies lengths aren't equal !");
            }
            return morse_matrix1;
        }

        //Realize crypt() with string parameter
        public string[] crypt(string word = "")
        {
            string[] strArr = new string[word.Length];
            for (int i = 0; i < word.Length; ++i)
            {
                for (int j = 0; j < Size2; ++j)
                {
                    if (word[i].ToString() == this[0, j])
                    {
                        strArr[i] = this[1, j];
                    }
                }
            }
            return strArr;
        }
        //Use indexers

        //Realize decrypt() with string array parameter
        //Use indexers
        public string decrypt(string[] words = null)
        {
            string str = "";
            for (int i = 0; i < words.Length; ++i)
            {
                StringBuilder sb = new StringBuilder(words[i]);
                for (int j = 0; j < words[i].Length; ++j)
                {
                    for (int k = 0; k < Size2; ++k)
                    {
                        if (words[i][j] == Convert.ToChar(this[1, j]))
                        {
                            sb[i] = Convert.ToChar(this[0, j]);
                        }
                    }
                }
                str += sb;
            }
            return str;
        }


        //Implement Res_beep() method with string parameter to beep the string
        public void Res_beep(string resultOfCrypting = "")
        {
            char[] arr = null;
            if (!string.IsNullOrEmpty(resultOfCrypting))
            { 
                 arr = new char[resultOfCrypting.Length];
            }
            else
            {
                throw new NullReferenceException();
            }
            for(int i = 0; i < resultOfCrypting.Length; ++i)
            {
                if (arr[i] == '.')
                {
                    Console.Beep(1, 1);
                }
                else if (arr[i] == '-')
                {
                    Console.Beep(1, 2);
                }
            }
            
        }
    }
}

