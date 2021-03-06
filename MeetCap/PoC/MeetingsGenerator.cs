using PoC.Extension;
using System.Collections.Generic;
using System.Linq;

namespace PoC
{
    public class MeetingsGenerator
    {
        public void GeneratePairs(List<Person> people, List<PreviousParing> previousParings)
        {
            var matches = new List<Match>();
            people.Shuffle();
            while(people.Count > 1)
            {
                var personToMatch = people.First();
                people.Remove(personToMatch);

                var previousMatches = previousParings.FirstOrDefault(pp => pp.PersonId == personToMatch.Id).PreviousParings;
                var match = GetMatch(people, previousMatches);

                people.Remove(match);
                matches.Add(new Match(personToMatch, match));
            }
            if(people.Count == 1 && matches.Count > 0)
            {
                matches.First().AddAdditionalOne(people.First());
            }
        }

        private Person GetMatch(List<Person> people, int[] previousMatches)
        {
            var match = people.FirstOrDefault(p => !previousMatches.Contains(p.Id));
            if (match == null)
            {
                match = people.FirstOrDefault();
            }
            return match;
        }
    }
}
