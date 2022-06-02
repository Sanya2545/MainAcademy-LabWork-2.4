using System;
using System.Text;

namespace Hello_Class_stud
{
    //Implement class Morse_matrix derived from String_matrix, which realize IMorse_crypt
    class Morse_matrix : String_matrix, IMorse_crypt
    {
        string[,] matrix;
        public const int Size_2 = Alphabet.Size;
        private int offset_key = 0;


        //Implement Morse_matrix constructor with the int parameter for offset
        public Morse_matrix(int offset = 0)
        {
            offset_key = offset;
            fd(Alphabet.Dictionary_arr);
            sd();
        }
        //Use fd(Alphabet.Dictionary_arr) and sd() methods
        public Morse_matrix(string [,] dict_arr = null, int offset = 0)
        {
            matrix = dict_arr;
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
            if(morse_matrix1.matrix.Length == morse_matrix2.matrix.Length)
            {
                for(int i = 0; i < morse_matrix1.matrix.GetLength(0); ++i)
                {
                    for(int j = 0; j < morse_matrix2.matrix.GetLength(1); ++j)
                    {
                        morse_matrix1.matrix[i, j] += morse_matrix2.matrix[i, j];
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
        public string crypt(string word = "")
        {
            StringBuilder sb = new StringBuilder(word);
            for (int i = 0; i < word.Length; ++i)
            {
                for (int j = 0; j < Size2; ++j)
                {
                    if (word[i] == Convert.ToChar(this[0, j]))
                    {
                        sb[i] = Convert.ToChar(this[1, j]);
                    }
                }
            }
            word = sb.ToString();
            return word;
        }
        //Use indexers

        //Realize decrypt() with string array parameter
        //Use indexers
        public string [] decrypt(string [] words = null)
        {

            return words;
        }


        //Implement Res_beep() method with string parameter to beep the string

    }
}

