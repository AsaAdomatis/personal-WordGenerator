// description: A struct represnting a single unit/phone in a word
public struct Phone
{
    public string Symbol;
    public int Weight;
    public List<string> Tags;
}

// description: An interface that represents a constraint that can be applied to a word
public interface IConstraint
{
    bool Test(string word);
}
// description: A class representing a the basic pattern for constructing a word
//              based of a string like "0.5(<consonant>)<vowel><liquid>(<consonant><vowel>[0.5<liquid>/0.5<plosive>])" 
//              for example.
public class Pattern {
    public string raw { get; set; }
    public Pattern(string rawPattern) {
        raw = rawPattern;      
    }

    public GenerateWord(List<Phone> phones)
    {
        
    }
}

// description: A class that when passed a series of phones and and constraints generates
//              words from those constraints
public class WordGenerator {
    public List<IConstraint> constraints { get; set; }
    public List<Phone> phones { get; set; }
    public Pattern pattern { get; set; }

    public List<string> Generate(int numWords) 
    {
        List<string> words = new List<string>();
        while (words.length() < numWords) 
        {
            // make word

            // test v. constraints
            bool satisfies = true;
            foreach(IConstraint constraint in Constraints)
            {
                if (!constraint.Test(word)) {
                    satisfies = false;
                    break;
                }
            }
            if (satisfies)
                words.append(word);

        }
        


    }


}