namespace Hello_Class_stud
{
    //Define interface IMorse_crypt wicth two methods  
    //crypt - to crypt the string
    //decrypt - to decrypt array of strings
    interface IMorse_crypt
    {
        string [] crypt(string word);
        string  decrypt(string [] words);
    }

}
