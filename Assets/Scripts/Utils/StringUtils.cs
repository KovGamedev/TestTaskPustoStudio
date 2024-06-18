using System;
using System.Linq;

public static class StringUtils
{
    public static String LeaveOnlyNumbers(String oldString) => string.Concat(oldString.Where(Char.IsDigit));
}
