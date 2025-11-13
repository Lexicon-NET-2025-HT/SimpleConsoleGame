using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleGame.Extensions;
internal static class MapExtensions
{
    public static IDrawable CreatureAt(this List<Creature> creatures, Cell cell)
    {
        IDrawable result = cell;

        foreach (Creature creature in creatures)
        {
            if (creature.Cell == result)
            {
                result = creature;
                break;
            }
        }

        return result;
    }
}
