namespace Basic.Extension
{
    /// <summary>
    /// System.String class Extension
    /// </summary>
    public static class StringExtenstion
    {

        /// <summary>
        /// 이 문자열 내에서, 지정된 특정 문자열 배열이 포함되는 여부를 bool로 반환합니다.
        /// </summary>
        /// <param name="str"> 대상 문자열. </param>
        /// <param name="value"> 지정된 특정 문자열 배열. </param>
        /// <returns>   true : 이 문자열 내에서 지정된 특정 문자열 배열이 포함되거나, value가 "" 이었을 때 <para/> 
        ///             false : 포함되지 않았을 때 </returns>
        public static bool Contains(this string str, params string[] value)
        {
            if (value == null || value.Length == 0)
            {
                throw new System.NullReferenceException();
            }
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

        /// <summary>
        /// 현재 System.String 개체에서 배열에 지정된 문자열 집합의 선행 항목을 모두 제거합니다.
        /// </summary>
        /// <param name="str"> 제거할 유니코드 문자열 배열이거나 null입니다. </param>
        /// <param name="trimStrings"></param>
        /// <returns>
        ///     trimChars 매개 변수의 문자가 현재 문자열의 시작 부분에서 모두 제거된 후 남아 있는 문자열입니다. <para/>
        ///     trimChars가 null이거나 빈 배열이면 공백 문자가 대신 제거됩니다.
        /// </returns>
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
