

async function test(dotnetReference) {
    const fpPromise = import('https://fpcdn.io/v3/snvG2aL45u7xaTAhoVZD')
        .then(FingerprintJS => FingerprintJS.load({
            region: "eu"
        }))
    fpPromise
        .then(fp => fp.get())
        .then(async result => {
            const visitorId = result.visitorId
            console.log(visitorId)
            await dotnetReference.invokeMethodAsync("CallbackJs", visitorId)
        })}