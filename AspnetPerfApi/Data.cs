using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

namespace AspnetPerfApi
{

    public class ElasticSearchResult
{
    public int Took { get; set; }
    public bool Timed_out { get; set; }
    public Shards _Shards { get; set; }
    public HitsContainer Hits { get; set; }
    public Aggregations Aggregations { get; set; }
}

public class Shards
{
    public int Total { get; set; }
    public int Successful { get; set; }
    public int Skipped { get; set; }
    public int Failed { get; set; }
}

public class HitsContainer
{
    public Total Total { get; set; }
    public double Max_score { get; set; }
    public List<Hit> Hits { get; set; }
}

public class Total
{
    public int Value { get; set; }
    public string Relation { get; set; }
}

public class Hit
{
    public string _Index { get; set; }
    public string _Id { get; set; }
    public double _Score { get; set; }
    public Source _Source { get; set; }
}

public class Source
{
    public int Webid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Combinedsearchtext { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; }
    public int StockLevel { get; set; }
    public string Color { get; set; }
    public int CategoryId { get; set; }
    public List<StringFacet> String_facet { get; set; }
}

public class StringFacet
{
    public string Facet_name { get; set; }
    public string Facet_value { get; set; }
}

public class Aggregations
{
    public FacetsContainer Facets { get; set; }
}

public class FacetsContainer
{
    public int Doc_count { get; set; }
    public Names Names { get; set; }
}

public class Names
{
    public int Doc_count_error_upper_bound { get; set; }
    public int Sum_other_doc_count { get; set; }
    public List<Bucket> Buckets { get; set; }
}

public class Bucket
{
    public string Key { get; set; }
    public int Doc_count { get; set; }
    public Values Values { get; set; }
}

public class Values
{
    public int Doc_count_error_upper_bound { get; set; }
    public int Sum_other_doc_count { get; set; }
    public List<Bucket> Buckets { get; set; }
}

public class Data
    {

        public static ElasticSearchResult? Deserialize()
        {
            string json = @"{
            ""took"": 18,
            ""timed_out"": false,
            ""_shards"": {
                ""total"": 1,
                ""successful"": 1,
                ""skipped"": 0,
                ""failed"": 0
            },
            ""hits"": {
                ""total"": {
                    ""value"": 100,
                    ""relation"": ""eq""
                },
                ""max_score"": 1,
                ""hits"": [
                    {
                        ""_index"": ""products-13"",
                        ""_id"": ""guyONJcBjv4AvNg2XIoG"",
                        ""_score"": 1,
                        ""_source"": {
                            ""webid"": 3,
                            ""title"": ""Enormous Steel Bench"",
                            ""description"": ""Built for efficiency, this product balances aesthetics and practical performance seamlessly."",
                            ""combinedsearchtext"": ""Enormous Steel Bench Built for efficiency, this product balances aesthetics and practical performance seamlessly. Teal Books"",
                            ""price"": 5,
                            ""categoryName"": ""Books"",
                            ""stockLevel"": 40,
                            ""color"": ""Teal"",
                            ""categoryId"": 6,
                            ""string_facet"": [
                                {
                                    ""facet_name"": ""Color"",
                                    ""facet_value"": ""Teal""
                                },
                                {
                                    ""facet_name"": ""Category"",
                                    ""facet_value"": ""Books""
                                }
                            ]
                        }
                    }
                ]
            },
            ""aggregations"": {
                ""facets"": {
                    ""doc_count"": 200,
                    ""names"": {
                        ""doc_count_error_upper_bound"": 0,
                        ""sum_other_doc_count"": 0,
                        ""buckets"": [
                            {
                                ""key"": ""Category"",
                                ""doc_count"": 100,
                                ""values"": {
                                    ""doc_count_error_upper_bound"": 0,
                                    ""sum_other_doc_count"": 0,
                                    ""buckets"": [
                                        {
                                            ""key"": ""Bla"",
                                            ""doc_count"": 23
                                        }
                                    ]
                                }
                            }
                        ]
                    }
                }
            }
        }";

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            var result = JsonSerializer.Deserialize<ElasticSearchResult>(json, options);
            //Console.WriteLine($"Deserialized successfully. Found {result.Hits.Hits.Count} hits.");
            return result;
        }


    }
}
