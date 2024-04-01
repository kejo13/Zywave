using System.Text.RegularExpressions;

namespace Zywave
{
    public class EmailFilterService
    {
        public (bool isClassified, string censoredText) FilterEmail(List<string> classifiedWords, string emailText)
        {
            bool isClassified = false;
            string censoredText = emailText;

            foreach (string word in classifiedWords)
            {
                if (emailText.Contains(word, System.StringComparison.OrdinalIgnoreCase))
                {
                    isClassified = true;
                    censoredText = Regex.Replace(censoredText, "\\b" + word + "\\b", "*****", RegexOptions.IgnoreCase);
                }
            }

            return (isClassified, censoredText);
        }
    }
}
