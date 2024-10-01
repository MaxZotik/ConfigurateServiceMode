using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurateService.Class.Devices
{
    public class ServiceSetting
    {
        public string IntervalOne { get; set; }

        public string IntervalTwo { get; set; }

        public string TimeGettingValues { get; set; }

        public string TimeGettingValuesPause { get; set; }

        public string TimeGettingValuesRepeat { get; set; }

        public string CoefficientGetPoint {  get; set; }

        public string CoefficientChecksVertex { get; set; }

        public string CountPointInterval {  get; set; }

        public string CoefficientKnock {  get; set; }

        public string PortServer {  get; set; }

        public ServiceSetting(string intervalOne, string intervalTwo, string timeGettingValues, string timeGettingValuesPause, string timeGettingValuesRepeat,
            string coefficientGetPoint, string coefficientChecksVertex, string countPointInterval, string coefficientKnock, string portServer)
        {
            IntervalOne = intervalOne;
            IntervalTwo = intervalTwo;
            TimeGettingValues = timeGettingValues;
            TimeGettingValuesPause = timeGettingValuesPause;
            TimeGettingValuesRepeat = timeGettingValuesRepeat;
            CoefficientGetPoint = coefficientGetPoint;
            CoefficientChecksVertex = coefficientChecksVertex;
            CountPointInterval = countPointInterval;
            CoefficientKnock = coefficientKnock;
            PortServer = portServer;
        }

        public ServiceSetting(string timeGettingValues, string timeGettingValuesPause, string timeGettingValuesRepeat,
            string coefficientGetPoint, string coefficientChecksVertex, string coefficientKnock, string portServer) : this (GetIntervalOne(timeGettingValues), 
                GetIntervalTwo(timeGettingValues), timeGettingValues, timeGettingValuesPause, timeGettingValuesRepeat,
            coefficientGetPoint, coefficientChecksVertex, GetCountPointInterval(timeGettingValues), coefficientKnock, portServer) { }


        private static string GetCountPointInterval(string timeGettingValues)
        {

            return ((int)Math.Ceiling(int.Parse(timeGettingValues) / 100.0)).ToString();
        }

        private static string GetIntervalTwo(string timeGettingValues)
        {
            float coef = 1.5f;

            return ((int)Math.Round(int.Parse(GetIntervalOne(timeGettingValues)) * coef)).ToString();
        }

        private static string GetIntervalOne(string timeGettingValues)
        {
            return ((int)Math.Round(int.Parse(timeGettingValues) * 2.0 / 10.0)).ToString();
        }

    }
}
