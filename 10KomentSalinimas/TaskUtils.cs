namespace KomentSalinimas
{
    public class TaskUtils
    {
        /** Removes comments and returns an indication
        about performed activity.
        @param line – line having possible comments
        @param newLine – line without comments */
        public static bool RemovesComments(string line, bool flag, out string newLine)
        {
            newLine = line;
            int start = 0;

            for (int i = 0; i < newLine.Length - 1; i++)
            {
                if (newLine[i] == '/' && newLine[i + 1] == '/')
                {
                    newLine = newLine.Remove(i);

                    flag = false;
                    break;
                }
                else if (newLine[i] == '/' && newLine[i + 1] == '*')
                {
                    flag = true;
                    start = i;
                }
                else if (newLine[i] == '*' && newLine[i + 1] == '/')
                {
                    newLine = newLine.Remove(start, i - start + 2);
                    flag = false;
                    i = start;
                }
            }

            if (flag)
            {
                newLine = newLine.Remove(start);
            }

            return flag;
        }
    }
}
