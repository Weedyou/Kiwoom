using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_hts {
    class Calculator {
        private List<int[]> date5PriceData = new List<int[]>();
        


        public void add5PriceData(int[] price) {
            date5PriceData.Add(price);
        }

        public void update5PriceData(int index, int[] price) {
            date5PriceData[index] = price;
        }

        public int[] getIndexArray5PriceData(int index) {
            return date5PriceData[index];
        }

        private double getRow5PriceData(int rowNumber, int index) {
            return date5PriceData[rowNumber][index];
        }

        public double calculate5MovingAverage(int rowNumber) {
            double sum =0;
            for (int i=0; i<5; i++) {
                sum += getRow5PriceData(rowNumber, i);
            }
            sum = sum / 5;
            string average = sum.ToString("#.##");
            return double.Parse(average.Trim());
        }

        public double calculate5Average(int[] price) {
            double sum = 0;
            for (int i = 0; i < 5; i++) {
                sum += price[i];
            }
            sum = sum / 5;
            string average = sum.ToString("#.##");
            return double.Parse(average.Trim());
        }
    }

    /*class AvgCalculater {
    public void calculate(ref List<PriceData> priceTable) {
        int maxIndex = priceTable.Count;
        int[] avgMax = { 5, 10, 20, 50, 100, 200 };  //평균 기준
        int avgIndex = 0;

        foreach (int avgTime in avgMax) {
            // ***단순 macd 구하기
            for (int index = 0; index < maxIndex; ++index) {
                int sumIndexMax = index + avgTime;
                if (sumIndexMax > maxIndex) {
                    break;
                }
                double sum = 0;
                for (int sumIndex = index; sumIndex < sumIndexMax; ++sumIndex) {
                    sum += priceTable[sumIndex].price_;
                }
                PriceData priceData = priceTable[index];
                if (avgTime == 0.0f) {
                    continue;
                }
                priceData.calc_[(int)EVALUATION_DATA.SMA_START + avgIndex] = sum / (double)avgTime;
            }

            // *** 지수 macd구하기
            // EMA(지수이동평균) = 전일지수이동평균 +{c×(금일종가지수-전일지수이동평균)}
            // ※ 단, 0 < c < 1(9일의 경우 0.2, 12일의 경우 0.15, 26일의 경우엔 가중치 0.075 사용)
            //   c = 2 / (n + 1)
            if ((avgMax[avgIndex] + 1) == 0) {
                continue;
            }
            double multiplier = 2.0f / (double)(avgMax[avgIndex] + 1);
            multiplier = Math.Min(0.999999f, Math.Max(multiplier, 0.000001f));

            int startIdx = maxIndex - avgMax[(int)avgIndex];
            startIdx--;
            double beforeEma = 0.0f;
            for (int index = startIdx; index >= 0; --index) {
                double ema = 0.0f;
                if (index == startIdx) {
                    ema = priceTable[index].calc_[(int)EVALUATION_DATA.SMA_START + avgIndex];
                }
                else {
                    double close = priceTable[index].price_;
                    ema = multiplier * (close - beforeEma) + beforeEma;
                }
                PriceData priceData = priceTable[index];
                priceData.calc_[(int)EVALUATION_DATA.EMA_START + avgIndex] = ema;

                beforeEma = ema;
            }
            ++avgIndex;
        }
    }
}*/

    /*enum PRICE_TYPE {
        TICK,           // tick 가격표
        MIN,            // 분 가격표
        DAY,            // 일 가격표
        MAX,
    };

    // 평균 샘플링
    enum AVG_SAMPLEING {
        AVG_5,                 //최근에서 5번
        AVG_10,                //10번 ...
        AVG_20,
        AVG_50,
        AVG_100,
        AVG_200,

        AVG_MAX,
    };

    // 평가 데이터
    enum EVALUATION_DATA {
        SMA_5,              //단순 이동평균
        SMA_10,
        SMA_20,
        SMA_50,
        SMA_100,
        SMA_200,

        EMA_5,              //지수 이동평균
        EMA_10,
        EMA_20,
        EMA_50,
        EMA_100,
        EMA_200,

        BOLLINGER_UPPER,    //볼린저
        BOLLINGER_CENTER,   //중심선
        BOLLINGER_LOWER,

        MACD,               //MACD
        MACD_SIGNAL,
        MACD_OSCIL,

        MAX,

        SMA_START = SMA_5,
        EMA_START = EMA_5,
        AVG_END = EMA_200 + 1,
    }

    struct PriceData : ICloneable {
        public string date_;

        public int price_;              //현재가
        public int startPrice_;         //시가
        public int highPrice_;          //고가
        public int lowPrice_;           //저가
        public double[] calc_;

        public PriceData(string date, int price, int startPrice, int highPrice, int lowPrice) {
            date_ = date;

            price_ = Math.Abs(price);
            startPrice_ = Math.Abs(startPrice);
            highPrice_ = Math.Abs(highPrice);
            lowPrice_ = Math.Abs(lowPrice);

            calc_ = new double[(int)EVALUATION_DATA.MAX];
        }

        public Object Clone() {
            PriceData clone = new PriceData(date_, price_, startPrice_, highPrice_, lowPrice_);

            calc_.CopyTo(clone.calc_, 0);

            return clone;
        }
    };*/
}

