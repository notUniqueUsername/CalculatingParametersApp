using System.Collections.Generic;

namespace CalculatingParametersLib
{
    public struct LoadGraph
    {
        public SortedList<string, double> RelatedData;
        public Params CurrentParams;
        public bool inParams;
        public double[][] data;
    }
}