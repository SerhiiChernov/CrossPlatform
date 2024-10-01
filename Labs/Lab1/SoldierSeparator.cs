namespace Lab1;

public class SoldierSeparator
{
    private int finalGroupCounter=0;

    public int Execute(int number)
    {
        return Separate(GenerateGroup(number));
    }
    private int Separate(List<int> soldiers)
    {
        int currentGroupCounter = soldiers.Count;

        if (currentGroupCounter > 3)
        {
            for (int i = 0; i < 2; i++)
            {
                var newGroup = GenerateGroup(i, 2, currentGroupCounter, soldiers);
                if (newGroup.Count > 4)
                    Separate(newGroup);
                else if (newGroup.Count == 3 || newGroup.Count == 4)
                    finalGroupCounter++;
                
                newGroup.Clear();
            }
            return finalGroupCounter;
        }
        else
        {
            return 0;
        }
    }

    private List<int> GenerateGroup(int startIndex, int step, int soldiersCount, List<int> soldiers)
    {
        List<int> group = new List<int>();
        for (int i = startIndex; i < soldiersCount; i +=step)
        {
            group.Add(soldiers[i]);
        }

        return group;
    }
    private List<int> GenerateGroup( int soldiersCount)
    {
        List<int> group = new List<int>();
        for (int i = 0; i < soldiersCount; i ++)
        {
            group.Add(i);
        }

        return group;
    }
}