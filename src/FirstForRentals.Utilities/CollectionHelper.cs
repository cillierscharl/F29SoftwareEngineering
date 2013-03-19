using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FirstForRentals.Entities;

namespace FirstForRentals.Utilities
{
    public class CollectionHelper
    {
        public static string ReturnCarClassCollection(DataSet dataSet)
        {
            var table = dataSet.Tables[0];
            var collection = new CarCollectionByClass();
            for (var x = 0; x < table.Rows.Count; x++)
            {
                collection.AddCar(table.Rows[x][0].ToString(),table.Rows[x][1].ToString(), table.Rows[x][2].ToString(),table.Rows[x][3].ToString(),table.Rows[x][4].ToString(),table.Rows[x][5].ToString());  
            }
            return collection.ToJson();
        }

        public static string ReturnCarCollectionOverview(DataSet dataSet)
        {
            var categoriesTable = dataSet.Tables[0];
            var detailTable = dataSet.Tables[1];

            var collectionContainer = new CarCollectionOverview();

            for (var x = 0; x < categoriesTable.Rows.Count; x++)
            {
                var collection = new CarCollection(categoriesTable.Rows[x][0].ToString());
                collectionContainer.AddCategory(collection);
            }

            for (var i = 0; i < detailTable.Rows.Count; i++)
            {
                var car = new CarDetail(detailTable.Rows[i][0].ToString(), detailTable.Rows[i][1].ToString(), 
                                        detailTable.Rows[i][2].ToString(), detailTable.Rows[i][3].ToString(), 
                                        detailTable.Rows[i][4].ToString(), detailTable.Rows[i][5].ToString(), 
                                        detailTable.Rows[i][6].ToString(), detailTable.Rows[i][7].ToString(), 
                                        detailTable.Rows[i][8].ToString(), detailTable.Rows[i][9].ToString(),
                                        detailTable.Rows[i][10].ToString());

                var collection = collectionContainer.FindCollectionByName(detailTable.Rows[i][1].ToString());
                collection.AddCar(car);
            }

            return collectionContainer.ToJson();
        }

        public static string ReturnCarStatus(DataSet dataSet)
        {
            var detailTable = dataSet.Tables[0];

            var car = new CarDetail(detailTable.Rows[0][0].ToString(), detailTable.Rows[0][1].ToString(),
                        detailTable.Rows[0][2].ToString(), detailTable.Rows[0][3].ToString(),
                        detailTable.Rows[0][4].ToString(), detailTable.Rows[0][5].ToString(),
                        detailTable.Rows[0][6].ToString(), detailTable.Rows[0][7].ToString(),
                        detailTable.Rows[0][8].ToString(), detailTable.Rows[0][9].ToString(),
                        detailTable.Rows[0][10].ToString());

            return car.ToJson();
        }

        public static string ReturnGraphData(DataSet dataSet)
        {
            var dataTable = dataSet.Tables[0];

            List<string> keys = new List<string>();
            List<List<string>>values = new List<List<string>>();
            for (var y = 1; y < dataTable.Columns.Count; y++)
            {
                keys.Add(dataTable.Columns[y].ToString());
            }

            for (var x = 0; x < dataTable.Rows.Count; x++)
            {
                List<string> value = new List<string>();
                for (var y = 0; y < dataTable.Columns.Count; y++)
                {
                    value.Add(dataTable.Rows[x][y].ToString());
                }
                values.Add(value);   
            }

            var collectionContainer = new GraphCollectionContainer(keys,values);
            return collectionContainer.ToJson();
        }

    }
}
