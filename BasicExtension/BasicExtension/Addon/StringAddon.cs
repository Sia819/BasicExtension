namespace Basic.Addon
{
    /// <summary>
    /// System.String class Addons
    /// </summary>
    public static class StringAddon
    {

        /// <summary>
        /// 이 문자열이 특정 문자열로 시작하는지를 나타내는 값을 반환합니다.
        /// </summary>
        /// <param name="str"> 대상 문자열입니다. </param>
        /// <param name="match"> 지정된 특정 문자열입니다. </param>
        /// <returns>   true : 이 문자열이 특정한 문자열로 시작하거나, 공백문자로 시작하는 경우입니다. <para/>
        ///             false : 이 문자열은 지정된 특정 문자열로 시작되지 않습니다. </returns>
        public static bool IfStart(this string str, string match)
        {
            int start = 0;
            int end = match.Length;
            return match.Length <= str.Length && str.Substring(start, end) == match ? true : false;
        }

        /// <summary>
        /// 이 인스턴스에서 부분 문자열을 검색합니다. <para/>
        /// 처음으로 찾은 first char과 그 다음으로 찾은 second char사이의 문자열의 값을 반환합니다. <para/>
        /// </summary>
        /// <param name="str"> 대상 문자열입니다. </param>
        /// <param name="first"> 처음으로 찾을 문자입니다. </param>
        /// <param name="second"> 두번째로 찾을 문자입니다. </param>
        /// <returns>
        ///     first char만 탐색된 경우 그 위치부터 문자열의 끝까지 반환됩니다. <para/>
        ///     second char만 탐색된 경우 문자열의 처음부터 해당 위치까지만 반환됩니다. <para/>
        ///     모두 탐색이 되지않은 경우 전체 문자열을 반환합니다.
        /// </returns>
        public static string SubstringFirst(this string str, char first, char second)
        {
            int f = -1, s = -1; // first와 second의 인덱스
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == first)
                {
                    f = i + 1;  // first는 현재인덱스 / first 다음의 인덱스
                }
                if (str[i] == second)    // first 가 정해진 경우
                {
                    s = i - 1;  // second는 현재인덱스 / second 이전의 인덱스
                    break;
                }
            }
            if (f != -1 && s != -1) // 둘다 찾음
            {
                return str.Substring(f, s);
            }
            else if (f != -1)   // 첫번째만 찾음
            {
                return str.Substring(f);
            }
            else if (s != -1)   // 두번째만 찾음
            {
                return str.Substring(0, s + 1);
            }
            else
            {
                return str;
            }
        }

        public static string[] SubstringFirst(this string str, string first, string second)
        {
            new System.NotImplementedException("아직 이 메서드는 구현되지 않았습니다.");
            return null;
        }

    }
}
