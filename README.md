YandexGeocoder
==============
C# Yandex.Maps Geocoder API library:
  - Finding a place by its name or address, and the determination its geographic coordinates - geocoding.

Usage
-----------
```
using Yandex;

GeoObjectCollection results = YandexGeocoder.Geocode("New York", 1, LangType.en_US);
foreach (GeoObject result in results)
{
    Console.WriteLine(result.Point.ToString());
}
```


Example
-----------
<img src="https://github.com/Verhov/YandexGeocoder/blob/master/example.png?raw=true" />

License
-----------
**Attention:** Solution is under development. Provided "AS IS", by MIT License.
