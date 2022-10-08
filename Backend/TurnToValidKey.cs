namespace Backend
{
    public static class TurnToValidKey
    {
        public static char Validate(string value)
        {
            if (value.Length == 1)
            {
                //returns the value as is because its just a letter
                return value[0];
            }
            else if (value.Length == 2)
            {
                // for the numbers because they start with D
                return value[1];
            }
            else
            {
                // these are for the symbols
                switch (value)
                {
                    case "oemminus":
                        return '-';
                    case "oemplus":
                        return '=';
                    case "oemopenbrackets":
                        return '[';
                    case "oemclosebrackets":
                        return ']';
                    case "oemsemicolon":
                        return ';';
                    case "oemquotes":
                        return '\'';
                    case "oempipe":
                        return '\\';
                    case "oemcomma":
                        return ',';
                    case "oemperiod":
                        return '.';
                    case "oemquestion":
                        return '/';
                    default:
                        throw new System.ArgumentException();
                }
            }
        }
    }    
}
