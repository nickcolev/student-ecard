# Demo 

Тази папка съдържа минимално демо за задачата. Този вариант може да бъде видян в действие на [pgmett.com/student-ecard](http://pgmett.com/student-ecard/).
Използва `student.php` като REST back-end.

## Локално

Копирайте файловете в `DocumentRoot` на вашия уеб сървър за да видите как работи този пример.

При локални тестове ползвайте IP адреса на компютъра, на който е web сървъра за да може мобилен телефон да се свърже с него.

## Windows

Може да позвате C# back-end като следва да:

1. Настроите CGI функционалност на web сървъра
2. Направите Release Build на Visual Studio проекта в папка `back-end`
3. Копирате изпълнимия код в `cgi-bin` папка на web сървъра като `student.exe`
4. Редактирате `index.html` да ползва `student.exe`

Ако web сървър е с PHP support може да ползвате `student.php`.

## Linux

Може да ползвате за back-end `student` shell скрипта като CGI или `student.php` ако web сървъра е с PHP support.
