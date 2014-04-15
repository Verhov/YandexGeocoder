YandexGeocoder
==============

Yandex geocoding service: http://api.yandex.com/maps/doc/geocoder/desc/concepts/About.xml

Home website: http://michael.verhov.com/en/post/yandex_geocoder


Capabilities
-----------
C# Yandex.Maps Geocoder API module:
  - Can determine geographical coordinates and other information about an object using its name or address.




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
<img src="https://github.com/Verhov/YandexGeocoder/blob/master/geocode_example.png?raw=true" />


Working notes
-----------
**Attention:** Solution is under development. Provided "AS IS", under MIT License.


The MIT License (MIT)
-----------
Copyright (c) 2013 michael verhov

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
