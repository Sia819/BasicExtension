using System;

namespace Extension.String
{
    public static class String_Ex
    {
        public static bool Contains(this string str, params string[] value)
        {
            bool result = false;
            foreach (var i in value)
            {
                result |= str.Contains(i);
            }
            return result;
        }

        public static bool StartMatch(this string str, string match)
        {
            int start = 0;
            int end = match.Length;
            return match.Length <= str.Length && str.Substring(start, end) == match ? true : false;
        }

        public static string TrimEnd(this string target, string trimString)
        {
            if (string.IsNullOrEmpty(trimString)) return target;

            string result = target;
            while (result.EndsWith(trimString))
            {
                result = result.Substring(0, result.Length - trimString.Length);
            }

            return result;
        }

        public static string TrimStart(this string target, string trimString)
        {
            if (string.IsNullOrEmpty(trimString)) return target;

            string result = target;
            while (result.StartsWith(trimString))
            {
                result = result.Substring(trimString.Length);
            }

            return result;
        }

        public static string TrimStart(this string str, params string[] trimStrings)
        {
            int end = str.Length;
            int resizeStart = 0;
            for (int start = 0; start < str.Length; start++)
            {
                int i = 0;
                for (i = 0; i < trimStrings.Length; i++)
                {
                    if (str.Substring(resizeStart, end - resizeStart).StartMatch(trimStrings[i]))   //Substring 대신 char비교하기
                    {
                        resizeStart += trimStrings[i].Length;
                        break;
                    }
                }
                if (i == trimStrings.Length)    //the string is not white space
                    break;
            }
            return str.Substring(resizeStart, end - resizeStart);
        }


        
    }
}
// A B C D E F G H I J K L M N O P Q R S T U V W X Y Z
