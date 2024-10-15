using Newtonsoft.Json;

namespace SonaHotelProject.Models
{
    public class HotelDetailViewModel
    {
            public string countrycode { get; set; }
            public int is_single_unit_vr { get; set; }
            public string country { get; set; }
            public string review_score_word { get; set; }
            public int is_vacation_rental { get; set; }
            public int main_photo_id { get; set; }
            public Checkin checkin { get; set; }
            public string currencycode { get; set; }
            public string hotel_facilities { get; set; }
            public string entrance_photo_url { get; set; }
            public string zip { get; set; }
            public int preferred { get; set; }
            public object district { get; set; }
            public string city { get; set; }
            public Location location { get; set; }
            public string main_photo_url { get; set; }
            public Languages_Spoken languages_spoken { get; set; }
            public string review_score { get; set; }
            public int hotel_id { get; set; }
            public int ranking { get; set; }
            public Description_Translations[] description_translations { get; set; }
            public float _class { get; set; }
            public int class_is_estimated { get; set; }
            public string email { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public int review_nr { get; set; }
            public int hoteltype_id { get; set; }
            public int city_id { get; set; }
            public int district_id { get; set; }
            public Booking_Home booking_home { get; set; }
            public Checkout checkout { get; set; }
            public string hotel_facilities_filtered { get; set; }
            public int preferred_plus { get; set; }
            public string address { get; set; }
        

        public class Checkin
        {
            public int _24_hour_available { get; set; }
            public string to { get; set; }
            public string from { get; set; }
        }

        public class Location
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

        public class Languages_Spoken
        {
            public string[] languagecode { get; set; }
        }

        public class Booking_Home
        {
            public int is_booking_home { get; set; }
            public int segment { get; set; }
            public string group { get; set; }
            public int is_aparthotel { get; set; }
            public int is_single_unit_property { get; set; }
            public int is_single_type_property { get; set; }
            public int is_vacation_rental { get; set; }
            public object quality_class { get; set; }
        }

        public class Checkout
        {
            public int _24_hour_available { get; set; }
            public string to { get; set; }
            public string from { get; set; }
        }

        public class Description_Translations
        {
            public string description { get; set; }
            public string languagecode { get; set; }
            public int descriptiontype_id { get; set; }
        }

    }
}





