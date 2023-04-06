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

public class PatternNode
{
    public string Value { get; set; }
    public List<PatternNode> Children { get; set; }

    public PatternNode(string value)
    {
        Value = value;
        Children = new List<PatternNode>();
    }

    public void AddChild(PatternNode child)
    {
        Children.Add(child);
    }

    public void RemoveChild(PatternNode child)
    {
        Children.Remove(child);
    }
}

// description: A class representing a the basic pattern for constructing a word
//              based of a string like "0.5(<consonant>)<vowel><liquid>(<consonant><vowel>[0.5<liquid>/0.5<plosive>])" 
//              for example.
public class Pattern {
    public string raw { get; set; }

    PatternNode _root;

    

    public Pattern(string rawPattern) {
        raw = rawPattern;      
        _root = new PatternNode("");

        // generating the pattern tree
        GenerateTree(_root, "");
        
    }

    private void GenerateTree(PatternNode head, int start, string from) {
        for (int i = start; i < raw.Length(); i++) {
            switch (raw[i]) {
                case "<":
                    string tag = "";
                    while (raw[i] != ">") {
                        tag += raw[i];
                        i++;
                    }
                    PatternNode node = new PatternNode(tag);
                    head.AddChild(node);
                    break;
                case "(":
                    if (head.Children.Length() > 0)
                        PatternNode node = new PatternNode("()");
                        head.AddChild(node);
                        GenerateTree(head.Children[head.Children.Length() - 1], i, "(");
                    break;
                case ")":
                    break;
            }
        }

    }

    string GenerateFrom(List<Phone> phones)
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