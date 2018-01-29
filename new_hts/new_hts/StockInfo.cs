using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_hts {
    public class StockInfo {
        private String stockCode;
        private String stockName;
        private int rowIndex;
        private String currentPrice;
        private String rateOfUpDown;
        private String amountOfVolume;

        public StockInfo(string jongmok_cd, string jongmok_nm, int index) {
            stockCode = jongmok_cd;
            stockName = jongmok_nm;
            rowIndex = index;
        }
        //가져오기함수
        public String getStockCode() {
            return stockCode;
        }
        public String getStockName() {
            return stockName;
        }
        public int getRowIndex() {
            return rowIndex;
        }
        public String getCurrentPrice() {
            return currentPrice;
        }
        public String getRateOfUpDown() {
            return rateOfUpDown;
        }
        public String getAmountOfVolume() {
            return amountOfVolume;
        }


        //설정함수
        public void setCurrentData(String price, String rate, String tradingAmount) {
            setCurrentPrice(price);
            setRateOfUpDown(rate);
            setAmountOfVolume(tradingAmount);
        }
        public void setCurrentPrice(String price) {
            currentPrice = price;
        }
        public void setRateOfUpDown(String rate) {
            rateOfUpDown = rate;
        }
        public void setAmountOfVolume(String tradingAmount) {
            amountOfVolume = tradingAmount;
        }


    }

}
