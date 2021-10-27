function addList (arr, id)
{
    for( i = 0; i < arr.length; ++i) {
        let newOption = new Option(arr[i], arr[i]);
        id.append(newOption);
    }
}