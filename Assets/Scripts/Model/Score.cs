using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Score
{

    public int Value { get; set; }

    public string GetScoreString { get { return Value + " Box"; } }

}
