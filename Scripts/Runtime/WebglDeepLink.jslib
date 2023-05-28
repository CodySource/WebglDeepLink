mergeInto(LibraryManager.library, {

  GetDeepLink: function () {
    var p = new URLSearchParams(window.location.search);
    instance.SendMessage('DeepLinker', 'RespondDeepLink', ((p.has('link'))? p.get('link') : 'null'));
  }

});