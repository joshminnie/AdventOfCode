import 'dart:io';

void main(List<String> args) {
  new File('day001/input.txt').readAsString().then((String contents) {
    var numbers = contents.trim().split("\n").map((n) => int.parse(n)).toList();

    for (var i = 0; i < numbers.length; i++) {
      for (var j = i; j < numbers.length - i; j++) {
        if (numbers[i] + numbers[j] == 2020) {
          print(numbers[i]);
          print(numbers[j]);
          print(numbers[i] * numbers[j]);
          return;
        }
      }
    }

    print('failed to find a matching number');
  });
}
