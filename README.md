# InternetArchiveApi
Basic wrapper for the Internet Archive's API (archive.org). Improvements welcome.

This project is not affiliated with or sponsored by the archive in any way.

# Usage
You have 3 options:
1. Published as a package to NuGet.org ('InternetArchiveApi')
2. For the bleeding edge code head to [MyGet](https://www.myget.org/feed/Packages/thebecwar)
3. Fork this repository and build from source.

# Dependencies
Depends on Newtonsoft.Json 10.0.3

# Documentation
To use this API wrapper in your project, create an instance of the `InternetArchive` class. The class provides two methods, `GetItem` and `RunQuery`. `GetItem` takes an item id (`string`) as it's only parameter. It returns an instance of `Rootobject` which wraps most of the API's response.

`RunQuery` takes a `Query` object which describes the search to perform, and returns a `Response` object which wraps the API's response. Within the `Query` object, `RequestFields` is a Flags enumeration that is used to specify the desired query fields, and the `SortBy` takes an array of up to three `QuerySort` objects. `QuerySort` objects can be set to use a default field (if `CustomField` is null or blank) or a customized field name (if `CustomField` has a value)

There's not much more to it. The API isn't fully supported in this wrapper.

# Contributions
Feel free to submit issues and pull requests.

# License
This project is licensed under the Beerware license - If you use this software, and you find it useful, and we ever meet in person, and you think it's worth a beer, then buy me one. Otherwise you're free to do whatever you want with it.
