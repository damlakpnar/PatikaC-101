using System;
using System.Collections.Generic;


namespace ToDoUygulaması
{
    public class Board
    {
        public Dictionary<Line,List<Card>> Lines {  get; set; }

        public Board() {
            Lines = new Dictionary<Line, List<Card>>
            {
                { Line.TODO, new List<Card>() },
                { Line.IN_PROGRESS, new List<Card>() },
                { Line.DONE, new List<Card>() }


            };


        }
        
    }
}
