using System;

namespace ToDoUygulaması
{
    public class Card
    {
        public string tittle {  get; set; }
        public string content { get; set; }
        public TeamMember AssignedTo { get; set; }
        public Size size { get; set; }
    }
}
