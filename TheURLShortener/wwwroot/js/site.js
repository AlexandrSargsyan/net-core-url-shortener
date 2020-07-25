$(() => {

    $("#generate").on('click', () => {

        var url = $("#url").val();
        var alias = $("#alias").val();
        var insertQuery = `/Redirect/Insert?url=${url}&alias=${alias}`;

        fetch(insertQuery).then((result) => {
            result.json().then(data => {
                if (data.id > 0) {
                    $("#alias").val(data.alias);
                    $("#short-url").attr('href', `/_/${data.alias}`)
                    $("#short-url").text(`https://localhost:44332/_/${data.alias}`);
                }

            });
        });

    });
});