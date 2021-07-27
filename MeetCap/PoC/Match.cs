using System;
using System.Collections.Generic;
using System.Text;

namespace PoC
{
    public class Match
    {
        public Person PersonOne { get; }
        public Person PersonTwo { get; }
        public Person Addtition { get; private set; }

        public Match(Person one, Person two)
        {
            PersonOne = one;
            PersonTwo = two;
        }

        public void AddAdditionalOne(Person third)
        {
            Addtition = third;
        }
    }
}
