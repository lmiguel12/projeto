﻿define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,
        search: function() {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: '', title:'Welcome', moduleId: 'viewmodels/welcome', nav: true },
                { route: 'flickr', moduleId: 'viewmodels/flickr', nav: true },
                { route: 'laureadoIndividuo', title: 'Laureados', moduleId: 'viewmodels/laureadoIndividuo', nav: true },
                { route: 'laureadoDetalhes/:id', moduleId: 'viewmodels/laureadoDetalhes', nav: false }
            ]).buildNavigationModel();
            
            return router.activate();
        }
    };
});