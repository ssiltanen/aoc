fn main() {
    let input = include_str!("../../../inputs/2015-01.txt");

    let part1: i32 = input.chars().map(|c| if c == '(' { 1 } else { -1 }).sum();

    let part2 = input
        .chars()
        .scan(0, |floor, c| {
            if *floor < 0 {
                return None;
            }

            *floor += if c == '(' { 1 } else { -1 };
            return Some(*floor);
        })
        .count();

    println!("2015-01/1: {part1}");
    println!("2015-01/2: {part2}");
}
