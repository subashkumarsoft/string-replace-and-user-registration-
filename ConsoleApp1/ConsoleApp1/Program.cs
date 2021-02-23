using System;
using System.Collections;

namespace replace_str
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                String st = "Hi Subash Kumar How are you?";
                char[] str = st.ToCharArray();
                translate(str);

            }catch(Exception ex)
            {
                Console.Write("Error: ",ex);
            }

        }

        static void translate(char[] str)
        {

            try
            {

                ArrayList arrayList = new ArrayList();
            string Temp = "";
            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] != ' ')
                {
                    Temp = Temp + str[i];
                    continue;
                }


                arrayList.Add(Temp);
                Temp = "";
            }

            arrayList.Add(Temp);
           

            Console.Write("Please Search a Word in 'Hi Subash Kumar How are you?': ");
            string Serval = Console.ReadLine();



            Console.Write("Enter a Word to replace: ");
            string Reval = Console.ReadLine();

            string newst = "";
            foreach (string s in arrayList)
            {

                if(s== Serval)
                {
                    newst += ' ' +Reval;

                }
                else
                {
                    newst +=' '+s;
                }
            }

           
            Console.Write("The modified string is :");
            Console.Write(newst);
            Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.Write("Error: ", ex);
            }
        }


    }



}
