using Business.Constants;

namespace Business.Domain
{
    public class Employee
    {
        public string Name { get; set; }

        public string SmallItem { get; set; }

        public string MediumItem { get; set; }

        public string LargeItem { get; set; }

        public double? SmallItemScore
        {
            get
            {
                if (SmallItem=="VG")
                    return CategoryTime.SmallTime/1.5;
                else if (SmallItem=="G")
                    return (double)CategoryTime.SmallTime;
                else if (SmallItem=="B")
                    return (double)CategoryTime.SmallTime*1.5;
                else
                    return 0;
            }
        }

        public double? MediumItemScore
        {
            get
            {
                if (SmallItem=="VG")
                    return CategoryTime.MediumTime/1.5;
                else if (SmallItem=="G")
                    return (double)CategoryTime.MediumTime;
                else if (SmallItem=="B")
                    return (double)CategoryTime.MediumTime*1.5;
                else
                    return 0;
            }
        }

        public double? LargeItemScore
        {
            get
            {
                if (SmallItem=="VG")
                    return CategoryTime.LargeTime/1.5;
                else if (SmallItem=="G")
                    return (double)CategoryTime.LargeTime;
                else if (SmallItem=="B")
                    return (double)CategoryTime.LargeTime*1.5;
                else
                    return 0;
            }
        }
    }
}
