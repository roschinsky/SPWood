# The lightweight alternative to SPMetal
This tool generates C#-code representing SharePoint lists or libraries to wrap their field names in enums and additional properties in summary-comments.

![SPWood client](https://troschinsky.files.wordpress.com/2015/11/spwood.png?w=630)

By using *enum.fieldName.ToString()* you can easily use SharePoint internal field names without the need to look them up, have them hard-coded in your application or creating bold configuration overhead. The true benefit of using SPWood-generated enums are the additional information presented in the intellisense summary about display name, field type, visibility, wether it is mandatory and if it is writable.

##### Placing hard-coded field names in your code
![Hard coded field names](https://troschinsky.files.wordpress.com/2014/08/accesslistitemfield_plain.jpg?w=630)
##### Using SPWood generated enums as field names
![SPWood enums as field names](https://troschinsky.files.wordpress.com/2014/08/accesslistitemfield_spwood.jpg?w=630)
