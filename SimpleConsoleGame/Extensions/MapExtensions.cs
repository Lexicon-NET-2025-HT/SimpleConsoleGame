using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConsoleGame.Extensions;
internal static class MapExtensions
{
    //Not used anymore implementation moved to map
    public static IDrawable? CreatureAt(this IEnumerable<Creature> creatures, Cell cell)
    {
        //IDrawable? result = null;

        //foreach (Creature creature in creatures)
        //{
        //    if (creature.Cell == cell)
        //    {
        //        result = creature;
        //        break;
        //    }
        //}

        //return result;

        return creatures.FirstOrDefault(c => c.Cell == cell);
    }
}
