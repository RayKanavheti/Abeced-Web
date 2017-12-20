/*$.stmode = $.stmode || {}; $.stmode.tplVars = $.stmode.tplVars || {}; $.stmode.tplVars.translations = { word_uppercase: "Uppercase", link_show_uppercase: "Show uppercase", error_set_no_languages: "No languages selected", error_set_title_blank: 'Please fill in the "Title"', error_card_back_blank: 'Please fill in the "Card Back"', error_card_front_blank: 'Please fill in the "Card Front"', error_subject_limit: "Subjects field should not consist of more than 250 characters", error_description_limit: "Description field should not consist of more than 2000 characters", error_username_contents: "Username must contain only letters, numbers, or dashes.", link_remove_favorite: "Remove from favorites", link_favorite_set: "Favorite this set", error_email_old_blank: "Please enter your old email address", error_email_invalid: "This is not a valid email address.", error_email_new_blank: "Please enter your new email address", error_change_password_old_match: "Your old password does not match our records.", error_password_too_short: "Your password must be at least six characters.", error_password_too_long: "Your password must be no more than 32 characters.", error_change_password_new_blank: "Your new password must not be blank.", error_change_password_not_match: "Your new passwords do not match.", password_strength_too_short: "Too short", password_strength_weak: "Weak", password_strength_fair: "Fair", password_strength_good: "Good", password_strength_strong: "Strong", developer_delete_confirmation: "Do you really want to delete this application?", word_select_all: "Select All", flashcard_discard_set: "Are you sure you want to discard the auto-saved set?", flashcard_no_changes_saved: "You haven't saved your changes on this set.", word_cards: "Cards", word_term: "term", word_autosaving: "Auto-saving", word_show: "Show", word_hide: "Hide", error_search_term: "Invalid search term. Please try again.", search_seek: "Seeking please wait", word_definition: "definition", word_hint: "hint", word_upload: "Upload", word_loading: "Loading", error_unknown: "An unknown error has occured, please, try again", word_front: "Front", word_image: "Image", word_back: "Back", error_different_columns: 'All columns should be different. "Please, choose another value for "', error_restart: "Something went wrong. Please restart page.", word_answer: "Answer", word_page: "Page", link_hide_hint: "Hide Hint", word_question: "Question", link_show_hint: "Show Hint", memorize_key_right: "i got it right", memorize_key_continue: "see answer/click to flip/continue", link_continue: "Continue", word_copy_answer: "Copy the answer", memorize_alphabetize_confirm: "Alphabetizing the set will restart the round. Are you sure?", word_incorrect: "Incorrect", memorize_you_answer: "You answered", word_correct: "Correct", link_start_over: "Start Over", memorize_continue_round: "Continue to Next Round", memorize_message_start_over: "Starting over will clear your progress? Are you sure you want to start over?", print_loading_pages: "Loading pages", error_valid_range: "Please enter a valid range", print_tip: "Printing Tip", print_duplex_message: "If your printer has duplex printing turn it on for double sided prints.", print_header_layout: "Layout Preview", print_study_at: "Study this set online at", print_url_cards: "flashcards", print_pdf: "Print PDF", error_search_tooshort: "Searches cannot contain less than 2 characters", error_name_blank: "Please enter a name", error_email_blank: "Please type in your email.", error_subject_blank: "Please enter a subject", error_message_blank: "Please enter a message", error_captcha_empty: "Please enter the verification RECAPTCHA.", error_report_blank: "Please enter your reason for reporting", error_app_title_blank: "Please enter a title for your app", error_app_desc_blank: "Please enter a description for your app", error_app_url_blank: "Please enter a url for your app", error_read_requirements: "Please read the requirements", error_username_blank: "Please enter your username.", error_username_too_short: "Your username must be at least four characters.", error_username_too_long_signin: "Your username cannot be more than one hundred characters.", error_password_blank: "Please enter your password.", error_username_valid: "Please enter a valid username", error_username_too_long: "Your username cannot be more than thirty-two characters.", error_no_answer: "You gave no answer", word_correct_match: "Correct Match", link_new_test: "Make New Test", rotational_social_sharing1: "TAKE OUR RELATIONSHIP PUBLIC...", rotational_social_sharing2: "DID YOU<br/>LIKE THIS?<br/>TELL YOUR FRIENDS...", rotational_social_sharing3: "CLICK THREE TIMES FOR GOOD LUCK", rotational_social_sharing4: "CALL ME MAYBE...", rotational_social_sharing5: "YOU KNOW YOU WANT TO...", rotational_social_sharing6: 'SIMON SAYS, "CLICK BELOW."', share_message_make_public_1: "In order to share this flashcard set, you must first make it viewable to others.", share_message_make_public_2: "Would you like to <strong>make this a public set</strong> now?", word_cancel: "Cancel", share_make_public: "Yes, make this set public", share_label_send: "Send to", share_email_placeholder: "email address separated by commas", share_send_message: "Send Message", share_disclaimer: "Your and your friends' emails will never be sold or shared with any outside company without your permission.", share_confirmation: "Thanks for sharing, <br/> your message has been sent", link_done: "Done", error_email_check: " is invalid. Please make sure all email addresses are correct.", error_enter_email_generic: "Please enter an email address.", link_next: "Next", link_prev: "Previous", flashcard_per_page: "cards per page", flashcard_showing: "Showing", word_both: "Both", word_of: "of", error_swear: "Flaschard Exchange is a is a clean learning community. We ask that you refrain from saying", search_your_search: "Your search for <strong>%query%</strong> retrieved no results." }; ; (function (d, c, b) { b(d).on("click", "#global-nav .site-logos a", function (f) { var h = b(this), g = h.parents(".site-logos").data("is-logged-in"); if (g) { b.get("/sso/get-token/site/" + h.data("site"), function (e) { if (e.success) { window.location = h.attr("href") + "/sso/auth?token=" + e.token + "&hash=" + e.hash } else { window.location = h.attr("href") } }); f.preventDefault() } }); b(".site-logos li").hover(function () { b(this).find("a").stop(true).fadeIn("slow") }, function () { b(this).find("a").stop(true).fadeOut("slow") }); function a() { b(document).ready(function () { b(".site-logos li").animate({ top: 0 }, 0); b("#flashcard-button span").delay(1200).fadeOut(); b("#essay-button a").show(); b("#essay-button a").delay(600).fadeOut(); b(".blue-arrow").delay(2000).animate({ top: "0" }, 600, "swing") }) } a() } (document, window, jQuery)); ; (function (a) { a.fn.tablePagination = function (b) { var c = { rowsPerPage: 5, currPage: 1, optionsForRows: [5, 10, 25, 50, 100], ignoreRows: [], topNav: false }; b = a.extend(c, b); return this.each(function () { var t = a(this)[0]; var h, f, m, i, k, v, r, j; h = "#tablePagination_totalPages"; f = "#tablePagination_currPage"; m = "#tablePagination_rowsPerPage"; i = "#tablePagination_firstPage"; k = "#tablePagination_prevPage"; v = "#tablePagination_nextPage"; r = "#tablePagination_lastPage"; j = "#tablePagination_paginater"; var s = (c.topNav) ? "prev" : "next"; var u = a.makeArray(a("tbody tr", t)); var l = a.grep(u, function (y, x) { return (a.inArray(y, c.ignoreRows) == -1) }, false); var d = l.length; var w = e(); var n = (c.currPage > w) ? 1 : c.currPage; if (a.inArray(c.rowsPerPage, c.optionsForRows) == -1) { c.optionsForRows.push(c.rowsPerPage) } function p(z) { if (z == 0 || z > w) { return } var A = (z - 1) * c.rowsPerPage; var y = (A + c.rowsPerPage - 1); a(l).show(); for (var x = 0; x < l.length; x++) { if (x < A || x > y) { a(l[x]).hide() } } } function e() { var y = Math.round(d / c.rowsPerPage); var x = (y * c.rowsPerPage < d) ? y + 1 : y; if (a(t)[s]().find(h).length > 0) { a(t)[s]().find(h).html(x) } if (x == 1) { a(j).hide() } else { a(j).show() } return x } function o(x) { if (x < 1 || x > w) { return } n = x; p(n); a(t)[s]().find(f).val(n) } function q() { var z = false; var A = c.optionsForRows; A.sort(function (C, B) { return C - B }); var y = a(t)[s]().find(m)[0]; y.length = 0; for (var x = 0; x < A.length; x++) { if (A[x] == c.rowsPerPage) { y.options[x] = new Option(A[x], A[x], true, true); z = true } else { y.options[x] = new Option(A[x], A[x]) } } if (!z) { c.optionsForRows == A[0] } } function g() { var x = []; x.push("<div id='tablePagination' class='pagination'>"); x.push("<p>" + a.stmode.translate("word_page") + " "); x.push("<input id='tablePagination_currPage' type='text' value='" + n + "' size='1'/>"); x.push(a.stmode.translate("word_of") + " <span id='tablePagination_totalPages'>" + w + "</span>"); x.push("</p>"); x.push("<p>&nbsp;&nbsp;|&nbsp;&nbsp;</p>"); x.push("<p>" + a.stmode.translate("flashcard_showing") + " "); x.push("<span id='tablePagination_perPage'>"); x.push("<select id='tablePagination_rowsPerPage'><option value='5'>5</option></select>"); x.push(a.stmode.translate("flashcard_per_page")); x.push("</span>"); x.push("</p>"); x.push("<ul id='nav-bar'>"); x.push("<span id='tablePagination_paginater'>"); x.push("<li><span id='tablePagination_prevPage'>" + a.stmode.translate("link_prev") + "</span></li>"); x.push("<li class='paginationSep'>|</li>"); x.push("<li><span id='tablePagination_nextPage' class='activeLink'>" + a.stmode.translate("link_next") + "</span></li>"); x.push("</span>"); x.push("</ul>"); x.push("</div>"); return x.join("").toString() } if (a(t)[s]().find(h).length == 0) { if (c.topNav) { a(this).before(g()) } else { a(this).after(g()) } if (w == 1) { a(j).hide() } } else { a(t)[s]().find(f).val(n) } q(); p(n); a(t)[s]().find(i).bind("click", function (x) { o(1) }); a(t)[s]().find(k).bind("click", function (x) { o(n - 1); if (n == 1) { a("#tablePagination_prevPage").removeClass("activeLink") } else { a("#tablePagination_prevPage").addClass("activeLink") } if (n < w) { a("#tablePagination_nextPage").addClass("activeLink") } }); a(t)[s]().find(v).bind("click", function (x) { o(parseInt(n) + 1); if (n == w) { a("#tablePagination_nextPage").removeClass("activeLink") } else { a("#tablePagination_nextPage").addClass("activeLink") } if (n > 1) { a("#tablePagination_prevPage").addClass("activeLink") } }); a(t)[s]().find(r).bind("click", function (x) { o(w) }); a(t)[s]().find(f).bind("change", function (x) { o(this.value) }); a(t)[s]().find(m).bind("change", function (x) { c.rowsPerPage = parseInt(this.value, 10); w = e(); o(1); a("#tablePagination_nextPage").addClass("activeLink"); a("#tablePagination_prevPage").removeClass("activeLink") }) }) } })(jQuery); ; (function (b) { function c(aZ, af) { function aY(h) { return aL.preferFlash && au && !aL.ignoreFlash && "undefined" !== typeof aL.flash[h] && aL.flash[h] } function aC(h) { return function (j) { var i = this._t; return !i || !i._a ? null : h.call(this, j) } } this.setupOptions = { url: aZ || null, flashVersion: 8, debugMode: !0, debugFlash: !1, useConsole: !0, consoleOnly: !0, waitForWindowLoad: !1, bgColor: "#ffffff", useHighPerformance: !1, flashPollingInterval: null, html5PollingInterval: null, flashLoadTimeout: 1000, wmode: null, allowScriptAccess: "always", useFlashBlock: !1, useHTML5Audio: !0, html5Test: /^(probably|maybe)$/i, preferFlash: !0, noSWFCache: !1 }; this.defaultOptions = { autoLoad: !1, autoPlay: !1, from: null, loops: 1, onid3: null, onload: null, whileloading: null, onplay: null, onpause: null, onresume: null, whileplaying: null, onposition: null, onstop: null, onfailure: null, onfinish: null, multiShot: !0, multiShotEvents: !1, position: null, pan: 0, stream: !0, to: null, type: null, usePolicyFile: !1, volume: 100 }; this.flash9Options = { isMovieStar: null, usePeakData: !1, useWaveformData: !1, useEQData: !1, onbufferchange: null, ondataerror: null }; this.movieStarOptions = { bufferTime: 3, serverURL: null, onconnect: null, duration: null }; this.audioFormats = { mp3: { type: ['audio/mpeg; codecs="mp3"', "audio/mpeg", "audio/mp3", "audio/MPA", "audio/mpa-robust"], required: !0 }, mp4: { related: ["aac", "m4a"], type: ['audio/mp4; codecs="mp4a.40.2"', "audio/aac", "audio/x-m4a", "audio/MP4A-LATM", "audio/mpeg4-generic"], required: !1 }, ogg: { type: ["audio/ogg; codecs=vorbis"], required: !1 }, wav: { type: ['audio/wav; codecs="1"', "audio/wav", "audio/wave", "audio/x-wav"], required: !1} }; this.movieID = "sm2-container"; this.id = af || "sm2movie"; this.debugID = "soundmanager-debug"; this.debugURLParam = /([#?&])debug=1/i; this.versionNumber = "V2.97a.20120624"; this.altURL = this.movieURL = this.version = null; this.enabled = this.swfLoaded = !1; this.oMC = null; this.sounds = {}; this.soundIDs = []; this.didFlashBlock = this.muted = !1; this.filePattern = null; this.filePatterns = { flash8: /\.mp3(\?.*)?$/i, flash9: /\.mp3(\?.*)?$/i }; this.features = { buffering: !1, peakData: !1, waveformData: !1, eqData: !1, movieStar: !1 }; this.sandbox = {}; var bz; try { bz = "undefined" !== typeof Audio && "undefined" !== typeof (new Audio).canPlayType } catch (by) { bz = !1 } this.hasHTML5 = bz; this.html5 = { usingFlash: null }; this.flash = {}; this.ignoreFlash = this.html5Only = !1; var a9, aL = this, aG = null, aX, ax = navigator.userAgent, aI = b, bp = aI.location.href.toString(), aD = document, a8, aJ, aH, aF, aq = [], a7 = !1, a6 = !1, aE = !1, av = !1, ag = !1, a5, aw, g, aW, bB, bj, bi, bg, ah, br, aV, aU, be, bf, aK, ai, aT, bd, A, I, bC, aS, bs, a4 = null, bD = null, at, bu, bc, aR, aP, bb, ay, a3 = !1, bk = !1, bh, aM, aj, bt = 0, a2 = null, bo, aB = null, ab, a1, a0, ap, aN, ak, bE, az, ao = Array.prototype.slice, am = !1, au, ac, bv, ar, bl, d = ax.match(/(ipad|iphone|ipod)/i), an = ax.match(/msie/i), ae = ax.match(/webkit/i), bw = ax.match(/safari/i) && !ax.match(/chrome/i), aO = ax.match(/opera/i), bm = ax.match(/(mobile|pre\/|xoom)/i) || d, al = !bp.match(/usehtml5audio/i) && !bp.match(/sm2\-ignorebadua/i) && bw && !ax.match(/silk/i) && ax.match(/OS X 10_6_([3-7])/i), bA = "undefined" !== typeof aD.hasFocus ? aD.hasFocus() : null, aA = bw && ("undefined" === typeof aD.hasFocus || !aD.hasFocus()), ad = !aA, e = /(mp3|mp4|mpa|m4a)/i, bq = aD.location ? aD.location.protocol.match(/http/i) : null, bx = !bq ? "http://" : "", bn = /^\s*audio\/(?:x-)?(?:mpeg4|aac|flv|mov|mp4||m4v|m4a|mp4v|3gp|3g2)\s*(?:$|;)/i, aQ = "mpeg4,aac,flv,mov,mp4,m4v,f4v,m4a,mp4v,3gp,3g2".split(","), f = RegExp("\\.(" + aQ.join("|") + ")(\\?.*)?$", "i"); this.mimePattern = /^\s*audio\/(?:x-)?(?:mp(?:eg|3))\s*(?:$|;)/i; this.useAltURL = !bq; this._global_a = null; if (bm && (aL.useHTML5Audio = !0, aL.preferFlash = !1, d)) { am = aL.ignoreFlash = !0 } this.setup = function (h) { "undefined" !== typeof h && aE && aB && aL.ok() && ("undefined" !== typeof h.flashVersion || "undefined" !== typeof h.url) && bb(at("setupLate")); g(h); return aL }; this.supported = this.ok = function () { return aB ? aE && !av : aL.useHTML5Audio && aL.hasHTML5 }; this.getMovie = function (h) { return aX(h) || aD[h] || aI[h] }; this.createSound = function (i, l) { function m() { h = aR(h); aL.sounds[k.id] = new a9(k); aL.soundIDs.push(k.id); return aL.sounds[k.id] } var h = null, j = null, k = null; if (!aE || !aL.ok()) { return bb(void 0), !1 } "undefined" !== typeof l && (i = { id: i, url: l }); h = aw(i); h.url = bo(h.url); k = h; if (ay(k.id, !0)) { return aL.sounds[k.id] } if (a1(k)) { j = m(), j._setup_html5(k) } else { if (8 < aF && null === k.isMovieStar) { k.isMovieStar = !(!k.serverURL && !(k.type && k.type.match(bn) || k.url.match(f))) } k = aP(k, void 0); j = m(); if (8 === aF) { aG._createSound(k.id, k.loops || 1, k.usePolicyFile) } else { if (aG._createSound(k.id, k.url, k.usePeakData, k.useWaveformData, k.useEQData, k.isMovieStar, k.isMovieStar ? k.bufferTime : !1, k.loops || 1, k.serverURL, k.duration || null, k.autoPlay, !0, k.autoLoad, k.usePolicyFile), !k.serverURL) { j.connected = !0, k.onconnect && k.onconnect.apply(j) } } !k.serverURL && (k.autoLoad || k.autoPlay) && j.load(k) } !k.serverURL && k.autoPlay && j.play(); return j }; this.destroySound = function (i, j) { if (!ay(i)) { return !1 } var k = aL.sounds[i], h; k._iO = {}; k.stop(); k.unload(); for (h = 0; h < aL.soundIDs.length; h++) { if (aL.soundIDs[h] === i) { aL.soundIDs.splice(h, 1); break } } j || k.destruct(!0); delete aL.sounds[i]; return !0 }; this.load = function (h, i) { return !ay(h) ? !1 : aL.sounds[h].load(i) }; this.unload = function (h) { return !ay(h) ? !1 : aL.sounds[h].unload() }; this.onposition = this.onPosition = function (i, j, k, h) { return !ay(i) ? !1 : aL.sounds[i].onposition(j, k, h) }; this.clearOnPosition = function (h, i, j) { return !ay(h) ? !1 : aL.sounds[h].clearOnPosition(i, j) }; this.start = this.play = function (h, i) { var j = !1; if (!aE || !aL.ok()) { return bb("soundManager.play(): " + at(!aE ? "notReady" : "notOK")), j } if (!ay(h)) { i instanceof Object || (i = { url: i }); if (i && i.url) { i.id = h, j = aL.createSound(i).play() } return j } return aL.sounds[h].play(i) }; this.setPosition = function (h, i) { return !ay(h) ? !1 : aL.sounds[h].setPosition(i) }; this.stop = function (h) { return !ay(h) ? !1 : aL.sounds[h].stop() }; this.stopAll = function () { for (var h in aL.sounds) { aL.sounds.hasOwnProperty(h) && aL.sounds[h].stop() } }; this.pause = function (h) { return !ay(h) ? !1 : aL.sounds[h].pause() }; this.pauseAll = function () { var h; for (h = aL.soundIDs.length - 1; 0 <= h; h--) { aL.sounds[aL.soundIDs[h]].pause() } }; this.resume = function (h) { return !ay(h) ? !1 : aL.sounds[h].resume() }; this.resumeAll = function () { var h; for (h = aL.soundIDs.length - 1; 0 <= h; h--) { aL.sounds[aL.soundIDs[h]].resume() } }; this.togglePause = function (h) { return !ay(h) ? !1 : aL.sounds[h].togglePause() }; this.setPan = function (h, i) { return !ay(h) ? !1 : aL.sounds[h].setPan(i) }; this.setVolume = function (h, i) { return !ay(h) ? !1 : aL.sounds[h].setVolume(i) }; this.mute = function (h) { var i = 0; "string" !== typeof h && (h = null); if (h) { return !ay(h) ? !1 : aL.sounds[h].mute() } for (i = aL.soundIDs.length - 1; 0 <= i; i--) { aL.sounds[aL.soundIDs[i]].mute() } return aL.muted = !0 }; this.muteAll = function () { aL.mute() }; this.unmute = function (h) { "string" !== typeof h && (h = null); if (h) { return !ay(h) ? !1 : aL.sounds[h].unmute() } for (h = aL.soundIDs.length - 1; 0 <= h; h--) { aL.sounds[aL.soundIDs[h]].unmute() } aL.muted = !1; return !0 }; this.unmuteAll = function () { aL.unmute() }; this.toggleMute = function (h) { return !ay(h) ? !1 : aL.sounds[h].toggleMute() }; this.getMemoryUse = function () { var h = 0; aG && 8 !== aF && (h = parseInt(aG._getMemoryUse(), 10)); return h }; this.disable = function (h) { var i; "undefined" === typeof h && (h = !1); if (av) { return !1 } av = !0; for (i = aL.soundIDs.length - 1; 0 <= i; i--) { bC(aL.sounds[aL.soundIDs[i]]) } a5(h); az.remove(aI, "load", bi); return !0 }; this.canPlayMIME = function (h) { var i; aL.hasHTML5 && (i = a0({ type: h })); !i && aB && (i = h && aL.ok() ? !!(8 < aF && h.match(bn) || h.match(aL.mimePattern)) : null); return i }; this.canPlayURL = function (h) { var i; aL.hasHTML5 && (i = a0({ url: h })); !i && aB && (i = h && aL.ok() ? !!h.match(aL.filePattern) : null); return i }; this.canPlayLink = function (h) { return "undefined" !== typeof h.type && h.type && aL.canPlayMIME(h.type) ? !0 : aL.canPlayURL(h.href) }; this.getSoundById = function (h) { if (!h) { throw Error("soundManager.getSoundById(): sID is null/undefined") } return aL.sounds[h] }; this.onready = function (h, j) { var i = !1; if ("function" === typeof h) { j || (j = aI), bB("onready", h, j), bj() } else { throw at("needFunction", "onready") } return !0 }; this.ontimeout = function (h, j) { var i = !1; if ("function" === typeof h) { j || (j = aI), bB("ontimeout", h, j), bj({ type: "ontimeout" }) } else { throw at("needFunction", "ontimeout") } return !0 }; this._wD = this._writeDebug = function () { return !0 }; this._debug = function () { }; this.reboot = function () { var h, i; for (h = aL.soundIDs.length - 1; 0 <= h; h--) { aL.sounds[aL.soundIDs[h]].destruct() } if (aG) { try { if (an) { bD = aG.innerHTML } a4 = aG.parentNode.removeChild(aG) } catch (j) { } } bD = a4 = aB = null; aL.enabled = aK = aE = a3 = bk = a7 = a6 = av = aL.swfLoaded = !1; aL.soundIDs = []; aL.sounds = {}; aG = null; for (h in aq) { if (aq.hasOwnProperty(h)) { for (i = aq[h].length - 1; 0 <= i; i--) { aq[h][i].fired = !1 } } } aI.setTimeout(aL.beginDelayedInit, 20) }; this.getMoviePercent = function () { return aG && "undefined" !== typeof aG.PercentLoaded ? aG.PercentLoaded() : null }; this.beginDelayedInit = function () { ag = !0; be(); setTimeout(function () { if (bk) { return !1 } aT(); aU(); return bk = !0 }, 20); bg() }; this.destruct = function () { aL.disable(!0) }; a9 = function (D) { var z, B, C = this, x, y, p, E, w, u, t = !1, v = [], j = 0, i, F, r = null; z = null; B = null; this.sID = this.id = D.id; this.url = D.url; this._iO = this.instanceOptions = this.options = aw(D); this.pan = this.options.pan; this.volume = this.options.volume; this.isHTML5 = !1; this._a = null; this.id3 = {}; this._debug = function () { }; this.load = function (h) { var l = null; if ("undefined" !== typeof h) { C._iO = aw(h, C.options), C.instanceOptions = C._iO } else { if (h = C.options, C._iO = h, C.instanceOptions = C._iO, r && r !== C.url) { C._iO.url = C.url, C.url = null } } if (!C._iO.url) { C._iO.url = C.url } C._iO.url = bo(C._iO.url); if (C._iO.url === C.url && 0 !== C.readyState && 2 !== C.readyState) { return 3 === C.readyState && C._iO.onload && C._iO.onload.apply(C, [!!C.duration]), C } h = C._iO; r = C.url; C.loaded = !1; C.readyState = 1; C.playState = 0; C.id3 = {}; if (a1(h)) { if (l = C._setup_html5(h), !l._called_load) { C._html5_canplay = !1; if (C._a.src !== h.url) { C._a.src = h.url, C.setPosition(0) } C._a.autobuffer = "auto"; C._a.preload = "auto"; l._called_load = !0; h.autoPlay && C.play() } } else { try { C.isHTML5 = !1, C._iO = aP(aR(h)), h = C._iO, 8 === aF ? aG._load(C.id, h.url, h.stream, h.autoPlay, h.whileloading ? 1 : 0, h.loops || 1, h.usePolicyFile) : aG._load(C.id, h.url, !!h.stream, !!h.autoPlay, h.loops || 1, !!h.autoLoad, h.usePolicyFile) } catch (k) { bd({ type: "SMSOUND_LOAD_JS_EXCEPTION", fatal: !0 }) } } return C }; this.unload = function () { if (0 !== C.readyState) { if (C.isHTML5) { if (E(), C._a) { C._a.pause(), aN(C._a, "about:blank"), C.url = "about:blank" } } else { 8 === aF ? aG._unload(C.id, "about:blank") : aG._unload(C.id) } x() } return C }; this.destruct = function (h) { if (C.isHTML5) { if (E(), C._a) { C._a.pause(), aN(C._a), am || p(), C._a._t = null, C._a = null } } else { C._iO.onfailure = null, aG._destroySound(C.id) } h || aL.destroySound(C.id, !0) }; this.start = this.play = function (h, m) { var k, l; l = !0; l = null; m = "undefined" === typeof m ? !0 : m; h || (h = {}); C._iO = aw(h, C._iO); C._iO = aw(C._iO, C.options); C._iO.url = bo(C._iO.url); C.instanceOptions = C._iO; if (C._iO.serverURL && !C.connected) { return C.getAutoPlay() || C.setAutoPlay(!0), C } a1(C._iO) && (C._setup_html5(C._iO), w()); if (1 === C.playState && !C.paused) { (k = C._iO.multiShot) || (l = C) } if (null !== l) { return l } if (!C.loaded) { if (0 === C.readyState) { if (!C.isHTML5) { C._iO.autoPlay = !0 } C.load(C._iO) } else { 2 === C.readyState && (l = C) } } if (null !== l) { return l } if (!C.isHTML5 && 9 === aF && 0 < C.position && C.position === C.duration) { h.position = 0 } if (C.paused && C.position && 0 < C.position) { C.resume() } else { C._iO = aw(h, C._iO); if (null !== C._iO.from && null !== C._iO.to && 0 === C.instanceCount && 0 === C.playState && !C._iO.serverURL) { k = function () { C._iO = aw(h, C._iO); C.play(C._iO) }; if (C.isHTML5 && !C._html5_canplay) { C.load({ _oncanplay: k }), l = !1 } else { if (!C.isHTML5 && !C.loaded && (!C.readyState || 2 !== C.readyState)) { C.load({ onload: k }), l = !1 } } if (null !== l) { return l } C._iO = F() } (!C.instanceCount || C._iO.multiShotEvents || !C.isHTML5 && 8 < aF && !C.getAutoPlay()) && C.instanceCount++; C._iO.onposition && 0 === C.playState && u(C); C.playState = 1; C.paused = !1; C.position = "undefined" !== typeof C._iO.position && !isNaN(C._iO.position) ? C._iO.position : 0; if (!C.isHTML5) { C._iO = aP(aR(C._iO)) } C._iO.onplay && m && (C._iO.onplay.apply(C), t = !0); C.setVolume(C._iO.volume, !0); C.setPan(C._iO.pan, !0); C.isHTML5 ? (w(), l = C._setup_html5(), C.setPosition(C._iO.position), l.play()) : (l = aG._start(C.id, C._iO.loops || 1, 9 === aF ? C._iO.position : C._iO.position / 1000, C._iO.multiShot), 9 === aF && !l && C._iO.onplayerror && C._iO.onplayerror.apply(C)) } return C }; this.stop = function (h) { var k = C._iO; if (1 === C.playState) { C._onbufferchange(0); C._resetOnPosition(0); C.paused = !1; if (!C.isHTML5) { C.playState = 0 } i(); k.to && C.clearOnPosition(k.to); if (C.isHTML5) { if (C._a) { h = C.position, C.setPosition(0), C.position = h, C._a.pause(), C.playState = 0, C._onTimer(), E() } } else { aG._stop(C.id, h), k.serverURL && C.unload() } C.instanceCount = 0; C._iO = {}; k.onstop && k.onstop.apply(C) } return C }; this.setAutoPlay = function (h) { C._iO.autoPlay = h; C.isHTML5 || (aG._setAutoPlay(C.id, h), h && !C.instanceCount && 1 === C.readyState && C.instanceCount++) }; this.getAutoPlay = function () { return C._iO.autoPlay }; this.setPosition = function (h) { "undefined" === typeof h && (h = 0); var l = C.isHTML5 ? Math.max(h, 0) : Math.min(C.duration || C._iO.duration, Math.max(h, 0)); C.position = l; h = C.position / 1000; C._resetOnPosition(C.position); C._iO.position = l; if (C.isHTML5) { if (C._a && C._html5_canplay && C._a.currentTime !== h) { try { C._a.currentTime = h, (0 === C.playState || C.paused) && C._a.pause() } catch (k) { } } } else { h = 9 === aF ? C.position : h, C.readyState && 2 !== C.readyState && aG._setPosition(C.id, h, C.paused || !C.playState, C._iO.multiShot) } C.isHTML5 && C.paused && C._onTimer(!0); return C }; this.pause = function (h) { if (C.paused || 0 === C.playState && 1 !== C.readyState) { return C } C.paused = !0; C.isHTML5 ? (C._setup_html5().pause(), E()) : (h || "undefined" === typeof h) && aG._pause(C.id, C._iO.multiShot); C._iO.onpause && C._iO.onpause.apply(C); return C }; this.resume = function () { var h = C._iO; if (!C.paused) { return C } C.paused = !1; C.playState = 1; C.isHTML5 ? (C._setup_html5().play(), w()) : (h.isMovieStar && !h.serverURL && C.setPosition(C.position), aG._pause(C.id, h.multiShot)); !t && h.onplay ? (h.onplay.apply(C), t = !0) : h.onresume && h.onresume.apply(C); return C }; this.togglePause = function () { if (0 === C.playState) { return C.play({ position: 9 === aF && !C.isHTML5 ? C.position : C.position / 1000 }), C } C.paused ? C.resume() : C.pause(); return C }; this.setPan = function (h, k) { "undefined" === typeof h && (h = 0); "undefined" === typeof k && (k = !1); C.isHTML5 || aG._setPan(C.id, h); C._iO.pan = h; if (!k) { C.pan = h, C.options.pan = h } return C }; this.setVolume = function (h, k) { "undefined" === typeof h && (h = 100); "undefined" === typeof k && (k = !1); if (C.isHTML5) { if (C._a) { C._a.volume = Math.max(0, Math.min(1, h / 100)) } } else { aG._setVolume(C.id, aL.muted && !C.muted || C.muted ? 0 : h) } C._iO.volume = h; if (!k) { C.volume = h, C.options.volume = h } return C }; this.mute = function () { C.muted = !0; if (C.isHTML5) { if (C._a) { C._a.muted = !0 } } else { aG._setVolume(C.id, 0) } return C }; this.unmute = function () { C.muted = !1; var h = "undefined" !== typeof C._iO.volume; if (C.isHTML5) { if (C._a) { C._a.muted = !1 } } else { aG._setVolume(C.id, h ? C._iO.volume : C.options.volume) } return C }; this.toggleMute = function () { return C.muted ? C.unmute() : C.mute() }; this.onposition = this.onPosition = function (h, l, k) { v.push({ position: parseInt(h, 10), method: l, scope: "undefined" !== typeof k ? k : C, fired: !1 }); return C }; this.clearOnPosition = function (h, k) { var l, h = parseInt(h, 10); if (isNaN(h)) { return !1 } for (l = 0; l < v.length; l++) { if (h === v[l].position && (!k || k === v[l].method)) { v[l].fired && j--, v.splice(l, 1) } } }; this._processOnPosition = function () { var h, k; h = v.length; if (!h || !C.playState || j >= h) { return !1 } for (h -= 1; 0 <= h; h--) { if (k = v[h], !k.fired && C.position >= k.position) { k.fired = !0, j++, k.method.apply(k.scope, [k.position]) } } return !0 }; this._resetOnPosition = function (h) { var k, l; k = v.length; if (!k) { return !1 } for (k -= 1; 0 <= k; k--) { if (l = v[k], l.fired && h <= l.position) { l.fired = !1, j-- } } return !0 }; F = function () { var h = C._iO, n = h.from, l = h.to, m, k; k = function () { C.clearOnPosition(l, k); C.stop() }; m = function () { if (null !== l && !isNaN(l)) { C.onPosition(l, k) } }; if (null !== n && !isNaN(n)) { h.position = n, h.multiShot = !1, m() } return h }; u = function () { var h, k = C._iO.onposition; if (k) { for (h in k) { if (k.hasOwnProperty(h)) { C.onPosition(parseInt(h, 10), k[h]) } } } }; i = function () { var h, k = C._iO.onposition; if (k) { for (h in k) { k.hasOwnProperty(h) && C.clearOnPosition(parseInt(h, 10)) } } }; w = function () { C.isHTML5 && bh(C) }; E = function () { C.isHTML5 && aM(C) }; x = function (h) { h || (v = [], j = 0); t = !1; C._hasTimer = null; C._a = null; C._html5_canplay = !1; C.bytesLoaded = null; C.bytesTotal = null; C.duration = C._iO && C._iO.duration ? C._iO.duration : null; C.durationEstimate = null; C.buffered = []; C.eqData = []; C.eqData.left = []; C.eqData.right = []; C.failures = 0; C.isBuffering = !1; C.instanceOptions = {}; C.instanceCount = 0; C.loaded = !1; C.metadata = {}; C.readyState = 0; C.muted = !1; C.paused = !1; C.peakData = { left: 0, right: 0 }; C.waveformData = { left: [], right: [] }; C.playState = 0; C.position = null; C.id3 = {} }; x(); this._onTimer = function (h) { var m, l = !1, k = {}; if (C._hasTimer || h) { if (C._a && (h || (0 < C.playState || 1 === C.readyState) && !C.paused)) { m = C._get_html5_duration(); if (m !== z) { z = m, C.duration = m, l = !0 } C.durationEstimate = C.duration; m = 1000 * C._a.currentTime || 0; m !== B && (B = m, l = !0); (l || h) && C._whileplaying(m, k, k, k, k) } return l } }; this._get_html5_duration = function () { var h = C._iO, k = C._a ? 1000 * C._a.duration : h ? h.duration : void 0; return k && !isNaN(k) && Infinity !== k ? k : h ? h.duration : null }; this._apply_loop = function (h, k) { h.loop = 1 < k ? "loop" : "" }; this._setup_html5 = function (l) { var l = aw(C._iO, l), o = decodeURI, q = am ? aL._global_a : C._a, m = o(l.url), n = q && q._t ? q._t.instanceOptions : null, k; if (q) { if (q._t) { if (!am && m === o(r)) { k = q } else { if (am && n.url === l.url && (!r || r === n.url)) { k = q } } if (k) { return C._apply_loop(q, l.loops), k } } am && q._t && q._t.playState && l.url !== n.url && q._t.stop(); x(n && n.url ? l.url === n.url : r ? r === l.url : !1); q.src = l.url; r = C.url = l.url; q._called_load = !1 } else { if (C._a = l.autoLoad || l.autoPlay ? new Audio(l.url) : aO ? new Audio(null) : new Audio, q = C._a, q._called_load = !1, am) { aL._global_a = q } } C.isHTML5 = !0; C._a = q; q._t = C; y(); C._apply_loop(q, l.loops); l.autoLoad || l.autoPlay ? C.load() : (q.autobuffer = !1, q.preload = "auto"); return q }; y = function () { if (C._a._added_events) { return !1 } var h; C._a._added_events = !0; for (h in ar) { ar.hasOwnProperty(h) && C._a && C._a.addEventListener(h, ar[h], !1) } return !0 }; p = function () { var h; C._a._added_events = !1; for (h in ar) { ar.hasOwnProperty(h) && C._a && C._a.removeEventListener(h, ar[h], !1) } }; this._onload = function (h) { h = !!h || !C.isHTML5 && 8 === aF && C.duration; C.loaded = h; C.readyState = h ? 3 : 2; C._onbufferchange(0); C._iO.onload && C._iO.onload.apply(C, [h]); return !0 }; this._onbufferchange = function (h) { if (0 === C.playState || h && C.isBuffering || !h && !C.isBuffering) { return !1 } C.isBuffering = 1 === h; C._iO.onbufferchange && C._iO.onbufferchange.apply(C); return !0 }; this._onsuspend = function () { C._iO.onsuspend && C._iO.onsuspend.apply(C); return !0 }; this._onfailure = function (h, l, k) { C.failures++; if (C._iO.onfailure && 1 === C.failures) { C._iO.onfailure(C, h, l, k) } }; this._onfinish = function () { var h = C._iO.onfinish; C._onbufferchange(0); C._resetOnPosition(0); if (C.instanceCount) { C.instanceCount--; if (!C.instanceCount && (i(), C.playState = 0, C.paused = !1, C.instanceCount = 0, C.instanceOptions = {}, C._iO = {}, E(), C.isHTML5)) { C.position = 0 } (!C.instanceCount || C._iO.multiShotEvents) && h && h.apply(C) } }; this._whileloading = function (h, n, l, m) { var k = C._iO; C.bytesLoaded = h; C.bytesTotal = n; C.duration = Math.floor(l); C.bufferLength = m; if (k.isMovieStar) { C.durationEstimate = C.duration } else { if (C.durationEstimate = k.duration ? C.duration > k.duration ? C.duration : k.duration : parseInt(C.bytesTotal / C.bytesLoaded * C.duration, 10), "undefined" === typeof C.durationEstimate) { C.durationEstimate = C.duration } } if (!C.isHTML5) { C.buffered = [{ start: 0, end: C.duration}] } (3 !== C.readyState || C.isHTML5) && k.whileloading && k.whileloading.apply(C) }; this._whileplaying = function (h, o, m, n, l) { var k = C._iO; if (isNaN(h) || null === h) { return !1 } C.position = Math.max(0, h); C._processOnPosition(); if (!C.isHTML5 && 8 < aF) { if (k.usePeakData && "undefined" !== typeof o && o) { C.peakData = { left: o.leftPeak, right: o.rightPeak} } if (k.useWaveformData && "undefined" !== typeof m && m) { C.waveformData = { left: m.split(","), right: n.split(",")} } if (k.useEQData && "undefined" !== typeof l && l && l.leftEQ && (h = l.leftEQ.split(","), C.eqData = h, C.eqData.left = h, "undefined" !== typeof l.rightEQ && l.rightEQ)) { C.eqData.right = l.rightEQ.split(",") } } 1 === C.playState && (!C.isHTML5 && 8 === aF && !C.position && C.isBuffering && C._onbufferchange(0), k.whileplaying && k.whileplaying.apply(C)); return !0 }; this._oncaptiondata = function (h) { C.captiondata = h; C._iO.oncaptiondata && C._iO.oncaptiondata.apply(C) }; this._onmetadata = function (h, n) { var l = {}, m, k; for (m = 0, k = h.length; m < k; m++) { l[h[m]] = n[m] } C.metadata = l; C._iO.onmetadata && C._iO.onmetadata.apply(C) }; this._onid3 = function (h, n) { var l = [], m, k; for (m = 0, k = h.length; m < k; m++) { l[h[m]] = n[m] } C.id3 = aw(C.id3, l); C._iO.onid3 && C._iO.onid3.apply(C) }; this._onconnect = function (h) { h = 1 === h; if (C.connected = h) { C.failures = 0, ay(C.id) && (C.getAutoPlay() ? C.play(void 0, C.getAutoPlay()) : C._iO.autoLoad && C.load()), C._iO.onconnect && C._iO.onconnect.apply(C, [h]) } }; this._ondataerror = function () { 0 < C.playState && C._iO.ondataerror && C._iO.ondataerror.apply(C) } }; ai = function () { return aD.body || aD._docElement || aD.getElementsByTagName("div")[0] }; aX = function (h) { return aD.getElementById(h) }; aw = function (i, k) { var l = i || {}, h, j; h = "undefined" === typeof k ? aL.defaultOptions : k; for (j in h) { h.hasOwnProperty(j) && "undefined" === typeof l[j] && (l[j] = "object" !== typeof h[j] || null === h[j] ? h[j] : aw(l[j], h[j])) } return l }; aW = { onready: 1, ontimeout: 1, defaultOptions: 1, flash9Options: 1, movieStarOptions: 1 }; g = function (i, l) { var m, h = !0, j = "undefined" !== typeof l, k = aL.setupOptions; for (m in i) { if (i.hasOwnProperty(m)) { if ("object" !== typeof i[m] || null === i[m] || i[m] instanceof Array) { j && "undefined" !== typeof aW[l] ? aL[l][m] = i[m] : "undefined" !== typeof k[m] ? (aL.setupOptions[m] = i[m], aL[m] = i[m]) : "undefined" === typeof aW[m] ? (bb(at("undefined" === typeof aL[m] ? "setupUndef" : "setupError", m), 2), h = !1) : aL[m] instanceof Function ? aL[m].apply(aL, i[m] instanceof Array ? i[m] : [i[m]]) : aL[m] = i[m] } else { if ("undefined" === typeof aW[m]) { bb(at("undefined" === typeof aL[m] ? "setupUndef" : "setupError", m), 2), h = !1 } else { return g(i[m], m) } } } } return h }; az = function () { function i(m) { var m = ao.call(m), l = m.length; j ? (m[1] = "on" + m[1], 3 < l && m.pop()) : 3 === l && m.push(!1); return m } function k(l, o) { var n = l.shift(), m = [h[o]]; if (j) { n[m](l[0], l[1]) } else { n[m].apply(n, l) } } var j = aI.attachEvent, h = { add: j ? "attachEvent" : "addEventListener", remove: j ? "detachEvent" : "removeEventListener" }; return { add: function () { k(i(arguments), "add") }, remove: function () { k(i(arguments), "remove") } } } (); ar = { abort: aC(function () { }), canplay: aC(function () { var h = this._t, j; if (h._html5_canplay) { return !0 } h._html5_canplay = !0; h._onbufferchange(0); j = "undefined" !== typeof h._iO.position && !isNaN(h._iO.position) ? h._iO.position / 1000 : null; if (h.position && this.currentTime !== j) { try { this.currentTime = j } catch (i) { } } h._iO._oncanplay && h._iO._oncanplay() }), canplaythrough: aC(function () { var h = this._t; h.loaded || (h._onbufferchange(0), h._whileloading(h.bytesLoaded, h.bytesTotal, h._get_html5_duration()), h._onload(!0)) }), ended: aC(function () { this._t._onfinish() }), error: aC(function () { this._t._onload(!1) }), loadeddata: aC(function () { var h = this._t; if (!h._loaded && !bw) { h.duration = h._get_html5_duration() } }), loadedmetadata: aC(function () { }), loadstart: aC(function () { this._t._onbufferchange(1) }), play: aC(function () { this._t._onbufferchange(0) }), playing: aC(function () { this._t._onbufferchange(0) }), progress: aC(function (i) { var m = this._t, l, h, j = 0, j = i.target.buffered; l = i.loaded || 0; var k = i.total || 1; m.buffered = []; if (j && j.length) { for (l = 0, h = j.length; l < h; l++) { m.buffered.push({ start: j.start(l), end: j.end(l) }) } j = j.end(0) - j.start(0); l = j / i.target.duration } isNaN(l) || (m._onbufferchange(0), m._whileloading(l, k, m._get_html5_duration()), l && k && l === k && ar.canplaythrough.call(this, i)) }), ratechange: aC(function () { }), suspend: aC(function (h) { var i = this._t; ar.progress.call(this, h); i._onsuspend() }), stalled: aC(function () { }), timeupdate: aC(function () { this._t._onTimer() }), waiting: aC(function () { this._t._onbufferchange(1) }) }; a1 = function (h) { return h.serverURL || h.type && aY(h.type) ? !1 : h.type ? a0({ type: h.type }) : a0({ url: h.url }) || aL.html5Only }; aN = function (h, i) { if (h) { h.src = i } }; a0 = function (i) { if (!aL.useHTML5Audio || !aL.hasHTML5) { return !1 } var j = i.url || null, i = i.type || null, k = aL.audioFormats, h; if (i && "undefined" !== typeof aL.html5[i]) { return aL.html5[i] && !aY(i) } if (!ap) { ap = []; for (h in k) { k.hasOwnProperty(h) && (ap.push(h), k[h].related && (ap = ap.concat(k[h].related))) } ap = RegExp("\\.(" + ap.join("|") + ")(\\?.*)?$", "i") } h = j ? j.toLowerCase().match(ap) : null; !h || !h.length ? i && (j = i.indexOf(";"), h = (-1 !== j ? i.substr(0, j) : i).substr(6)) : h = h[1]; h && "undefined" !== typeof aL.html5[h] ? j = aL.html5[h] && !aY(h) : (i = "audio/" + h, j = aL.html5.canPlayType({ type: i }), j = (aL.html5[h] = j) && aL.html5[i] && !aY(i)); return j }; bE = function () { function i(o) { var n, q, p = n = !1; if (!l || "function" !== typeof l.canPlayType) { return n } if (o instanceof Array) { for (n = 0, q = o.length; n < q && !p; n++) { if (aL.html5[o[n]] || l.canPlayType(o[n]).match(aL.html5Test)) { p = !0, aL.html5[o[n]] = !0, aL.flash[o[n]] = !!o[n].match(e) } } n = p } else { o = l && "function" === typeof l.canPlayType ? l.canPlayType(o) : !1, n = !(!o || !o.match(aL.html5Test)) } return n } if (!aL.useHTML5Audio || "undefined" === typeof Audio) { return !1 } var l = "undefined" !== typeof Audio ? aO ? new Audio(null) : new Audio : null, m, h, j = {}, k; k = aL.audioFormats; for (m in k) { if (k.hasOwnProperty(m) && (h = "audio/" + m, j[m] = i(k[m].type), j[h] = j[m], m.match(e) ? (aL.flash[m] = !0, aL.flash[h] = !0) : (aL.flash[m] = !1, aL.flash[h] = !1), k[m] && k[m].related)) { for (h = k[m].related.length - 1; 0 <= h; h--) { j["audio/" + k[m].related[h]] = j[m], aL.html5[k[m].related[h]] = j[m], aL.flash[k[m].related[h]] = j[m] } } } j.canPlayType = l ? i : null; aL.html5 = aw(aL.html5, j); return !0 }; at = function () { }; aR = function (h) { if (8 === aF && 1 < h.loops && h.stream) { h.stream = !1 } return h }; aP = function (h) { if (h && !h.usePolicyFile && (h.onid3 || h.usePeakData || h.useWaveformData || h.useEQData)) { h.usePolicyFile = !0 } return h }; bb = function () { }; a8 = function () { return !1 }; bC = function (h) { for (var i in h) { h.hasOwnProperty(i) && "function" === typeof h[i] && (h[i] = a8) } }; aS = function (h) { "undefined" === typeof h && (h = !1); (av || h) && aL.disable(h) }; bs = function (h) { var i = null; if (h) { if (h.match(/\.swf(\?.*)?$/i)) { if (i = h.substr(h.toLowerCase().lastIndexOf(".swf?") + 4)) { return h } } else { h.lastIndexOf("/") !== h.length - 1 && (h += "/") } } h = (h && -1 !== h.lastIndexOf("/") ? h.substr(0, h.lastIndexOf("/") + 1) : "./") + aL.movieURL; aL.noSWFCache && (h += "?ts=" + (new Date).getTime()); return h }; br = function () { aF = parseInt(aL.flashVersion, 10); if (8 !== aF && 9 !== aF) { aL.flashVersion = aF = 8 } var h = aL.debugMode || aL.debugFlash ? "_debug.swf" : ".swf"; if (aL.useHTML5Audio && !aL.html5Only && aL.audioFormats.mp4.required && 9 > aF) { aL.flashVersion = aF = 9 } aL.version = aL.versionNumber + (aL.html5Only ? " (HTML5-only mode)" : 9 === aF ? " (AS3/Flash 9)" : " (AS2/Flash 8)"); 8 < aF ? (aL.defaultOptions = aw(aL.defaultOptions, aL.flash9Options), aL.features.buffering = !0, aL.defaultOptions = aw(aL.defaultOptions, aL.movieStarOptions), aL.filePatterns.flash9 = RegExp("\\.(mp3|" + aQ.join("|") + ")(\\?.*)?$", "i"), aL.features.movieStar = !0) : aL.features.movieStar = !1; aL.filePattern = aL.filePatterns[8 !== aF ? "flash9" : "flash8"]; aL.movieURL = (8 === aF ? "soundmanager2.swf" : "soundmanager2_flash9.swf").replace(".swf", h); aL.features.peakData = aL.features.waveformData = aL.features.eqData = 8 < aF }; A = function (h, i) { if (!aG) { return !1 } aG._setPolling(h, i) }; I = function () { if (aL.debugURLParam.test(bp)) { aL.debugMode = !0 } }; ay = this.getSoundById; bc = function () { var h = []; aL.debugMode && h.push("sm2_debug"); aL.debugFlash && h.push("flash_debug"); aL.useHighPerformance && h.push("high_performance"); return h.join(" ") }; bu = function () { at("fbHandler"); var h = aL.getMoviePercent(), i = { type: "FLASHBLOCK" }; if (aL.html5Only) { return !1 } if (aL.ok()) { if (aL.oMC) { aL.oMC.className = [bc(), "movieContainer", "swf_loaded" + (aL.didFlashBlock ? " swf_unblocked" : "")].join(" ") } } else { if (aB) { aL.oMC.className = bc() + " movieContainer " + (null === h ? "swf_timedout" : "swf_error") } aL.didFlashBlock = !0; bj({ type: "ontimeout", ignoreInit: !0, error: i }); bd(i) } }; bB = function (h, j, i) { "undefined" === typeof aq[h] && (aq[h] = []); aq[h].push({ method: j, scope: i || null, fired: !1 }) }; bj = function (i) { i || (i = { type: aL.ok() ? "onready" : "ontimeout" }); if (!aE && i && !i.ignoreInit || "ontimeout" === i.type && (aL.ok() || av && !i.ignoreInit)) { return !1 } var l = { success: i && i.ignoreInit ? aL.ok() : !av }, m = i && i.type ? aq[i.type] || [] : [], h = [], j, l = [l], k = aB && aL.useFlashBlock && !aL.ok(); if (i.error) { l[0].error = i.error } for (i = 0, j = m.length; i < j; i++) { !0 !== m[i].fired && h.push(m[i]) } if (h.length) { for (i = 0, j = h.length; i < j; i++) { if (h[i].scope ? h[i].method.apply(h[i].scope, l) : h[i].method.apply(this, l), !k) { h[i].fired = !0 } } } return !0 }; bi = function () { aI.setTimeout(function () { aL.useFlashBlock && bu(); bj(); "function" === typeof aL.onload && aL.onload.apply(aI); aL.waitForWindowLoad && az.add(aI, "load", bi) }, 1) }; ac = function () { if ("undefined" !== typeof au) { return au } var i = !1, m = navigator, l = m.plugins, h, j = aI.ActiveXObject; if (l && l.length) { (m = m.mimeTypes) && m["application/x-shockwave-flash"] && m["application/x-shockwave-flash"].enabledPlugin && m["application/x-shockwave-flash"].enabledPlugin.description && (i = !0) } else { if ("undefined" !== typeof j) { try { h = new j("ShockwaveFlash.ShockwaveFlash") } catch (k) { } i = !!h } } return au = i }; ab = function () { var h, i, j = aL.audioFormats; if (d && ax.match(/os (1|2|3_0|3_1)/i)) { if (aL.hasHTML5 = !1, aL.html5Only = !0, aL.oMC) { aL.oMC.style.display = "none" } } else { if (aL.useHTML5Audio) { aL.hasHTML5 = !aL.html5 || !aL.html5.canPlayType ? !1 : !0 } } if (aL.useHTML5Audio && aL.hasHTML5) { for (i in j) { if (j.hasOwnProperty(i) && (j[i].required && !aL.html5.canPlayType(j[i].type) || aL.preferFlash && (aL.flash[i] || aL.flash[j[i].type]))) { h = !0 } } } aL.ignoreFlash && (h = !1); aL.html5Only = aL.hasHTML5 && aL.useHTML5Audio && !h; return !aL.html5Only }; bo = function (i) { var j, k, h = 0; if (i instanceof Array) { for (j = 0, k = i.length; j < k; j++) { if (i[j] instanceof Object) { if (aL.canPlayMIME(i[j].type)) { h = j; break } } else { if (aL.canPlayURL(i[j])) { h = j; break } } } if (i[h].url) { i[h] = i[h].url } i = i[h] } return i }; bh = function (h) { if (!h._hasTimer) { h._hasTimer = !0, !bm && aL.html5PollingInterval && (null === a2 && 0 === bt && (a2 = aI.setInterval(aj, aL.html5PollingInterval)), bt++) } }; aM = function (h) { if (h._hasTimer) { h._hasTimer = !1, !bm && aL.html5PollingInterval && bt-- } }; aj = function () { var h; if (null !== a2 && !bt) { return aI.clearInterval(a2), a2 = null, !1 } for (h = aL.soundIDs.length - 1; 0 <= h; h--) { aL.sounds[aL.soundIDs[h]].isHTML5 && aL.sounds[aL.soundIDs[h]]._hasTimer && aL.sounds[aL.soundIDs[h]]._onTimer() } }; bd = function (h) { h = "undefined" !== typeof h ? h : {}; "function" === typeof aL.onerror && aL.onerror.apply(aI, [{ type: "undefined" !== typeof h.type ? h.type : null}]); "undefined" !== typeof h.fatal && h.fatal && aL.disable() }; bv = function () { if (!al || !ac()) { return !1 } var h = aL.audioFormats, i, j; for (j in h) { if (h.hasOwnProperty(j) && ("mp3" === j || "mp4" === j)) { if (aL.html5[j] = !1, h[j] && h[j].related) { for (i = h[j].related.length - 1; 0 <= i; i--) { aL.html5[h[j].related[i]] = !1 } } } } }; this._setSandboxType = function () { }; this._externalInterfaceOK = function () { if (aL.swfLoaded) { return !1 } (new Date).getTime(); aL.swfLoaded = !0; aA = !1; al && bv(); setTimeout(aH, an ? 100 : 1) }; aT = function (y, v) { function w(i, h) { return '<param name="' + i + '" value="' + h + '" />' } if (a7 && a6) { return !1 } if (aL.html5Only) { return br(), aL.oMC = aX(aL.movieID), aH(), a6 = a7 = !0, !1 } var x = v || aL.url, t = aL.altURL || x, u; u = ai(); var s, r, q = bc(), p, o = null, o = (o = aD.getElementsByTagName("html")[0]) && o.dir && o.dir.match(/rtl/i), y = "undefined" === typeof y ? aL.id : y; br(); aL.url = bs(bq ? x : t); v = aL.url; aL.wmode = !aL.wmode && aL.useHighPerformance ? "transparent" : aL.wmode; if (null !== aL.wmode && (ax.match(/msie 8/i) || !an && !aL.useHighPerformance) && navigator.platform.match(/win32|win64/i)) { aL.wmode = null } u = { name: y, id: y, src: v, quality: "high", allowScriptAccess: aL.allowScriptAccess, bgcolor: aL.bgColor, pluginspage: bx + "www.macromedia.com/go/getflashplayer", title: "JS/Flash audio component (SoundManager 2)", type: "application/x-shockwave-flash", wmode: aL.wmode, hasPriority: "true" }; if (aL.debugFlash) { u.FlashVars = "debug=1" } aL.wmode || delete u.wmode; if (an) { x = aD.createElement("div"), r = ['<object id="' + y + '" data="' + v + '" type="' + u.type + '" title="' + u.title + '" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="' + bx + 'download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0">', w("movie", v), w("AllowScriptAccess", aL.allowScriptAccess), w("quality", u.quality), aL.wmode ? w("wmode", aL.wmode) : "", w("bgcolor", aL.bgColor), w("hasPriority", "true"), aL.debugFlash ? w("FlashVars", u.FlashVars) : "", "</object>"].join("") } else { for (s in x = aD.createElement("embed"), u) { u.hasOwnProperty(s) && x.setAttribute(s, u[s]) } } I(); q = bc(); if (u = ai()) { if (aL.oMC = aX(aL.movieID) || aD.createElement("div"), aL.oMC.id) { p = aL.oMC.className; aL.oMC.className = (p ? p + " " : "movieContainer") + (q ? " " + q : ""); aL.oMC.appendChild(x); if (an) { s = aL.oMC.appendChild(aD.createElement("div")), s.className = "sm2-object-box", s.innerHTML = r } a6 = !0 } else { aL.oMC.id = aL.movieID; aL.oMC.className = "movieContainer " + q; s = q = null; if (!aL.useFlashBlock) { if (aL.useHighPerformance) { q = { position: "fixed", width: "8px", height: "8px", bottom: "0px", left: "0px", overflow: "hidden"} } else { if (q = { position: "absolute", width: "6px", height: "6px", top: "-9999px", left: "-9999px" }, o) { q.left = Math.abs(parseInt(q.left, 10)) + "px" } } } if (ae) { aL.oMC.style.zIndex = 10000 } if (!aL.debugFlash) { for (p in q) { q.hasOwnProperty(p) && (aL.oMC.style[p] = q[p]) } } try { an || aL.oMC.appendChild(x); u.appendChild(aL.oMC); if (an) { s = aL.oMC.appendChild(aD.createElement("div")), s.className = "sm2-object-box", s.innerHTML = r } a6 = !0 } catch (l) { throw Error(at("domError") + " \n" + l.toString()) } } } return a7 = !0 }; aU = function () { if (aL.html5Only) { return aT(), !1 } if (aG) { return !1 } aG = aL.getMovie(aL.id); if (!aG) { a4 ? (an ? aL.oMC.innerHTML = bD : aL.oMC.appendChild(a4), a4 = null, a7 = !0) : aT(aL.id, aL.url), aG = aL.getMovie(aL.id) } "function" === typeof aL.oninitmovie && setTimeout(aL.oninitmovie, 1); return !0 }; bg = function () { setTimeout(ah, 1000) }; ah = function () { var h, i = !1; if (a3) { return !1 } a3 = !0; az.remove(aI, "load", bg); if (aA && !bA) { return !1 } aE || (h = aL.getMoviePercent(), 0 < h && 100 > h && (i = !0)); setTimeout(function () { h = aL.getMoviePercent(); if (i) { return a3 = !1, aI.setTimeout(bg, 1), !1 } !aE && ad && (null === h ? aL.useFlashBlock || 0 === aL.flashLoadTimeout ? aL.useFlashBlock && bu() : aS(!0) : 0 !== aL.flashLoadTimeout && aS(!0)) }, aL.flashLoadTimeout) }; aV = function () { if (bA || !aA) { return az.remove(aI, "focus", aV), !0 } bA = ad = !0; a3 = !1; bg(); az.remove(aI, "focus", aV); return !0 }; bl = function () { var h, i = []; if (aL.useHTML5Audio && aL.hasHTML5) { for (h in aL.audioFormats) { aL.audioFormats.hasOwnProperty(h) && i.push(h + ": " + aL.html5[h] + (!aL.html5[h] && au && aL.flash[h] ? " (using flash)" : aL.preferFlash && aL.flash[h] && au ? " (preferring flash)" : !aL.html5[h] ? " (" + (aL.audioFormats[h].required ? "required, " : "") + "and no flash support)" : "")) } } }; a5 = function (h) { if (aE) { return !1 } if (aL.html5Only) { return aE = !0, bi(), !0 } var i = !0, j; if (!aL.useFlashBlock || !aL.flashLoadTimeout || aL.getMoviePercent()) { aE = !0, av && (j = { type: !au && aB ? "NO_FLASH" : "INIT_TIMEOUT" }) } if (av || h) { if (aL.useFlashBlock && aL.oMC) { aL.oMC.className = bc() + " " + (null === aL.getMoviePercent() ? "swf_timedout" : "swf_error") } bj({ type: "ontimeout", error: j, ignoreInit: !0 }); bd(j); i = !1 } av || (aL.waitForWindowLoad && !ag ? az.add(aI, "load", bi) : bi()); return i }; aJ = function () { var h, i = aL.setupOptions; for (h in i) { i.hasOwnProperty(h) && ("undefined" === typeof aL[h] ? aL[h] = i[h] : aL[h] !== i[h] && (aL.setupOptions[h] = aL[h])) } }; aH = function () { if (aE) { return !1 } if (aL.html5Only) { if (!aE) { az.remove(aI, "load", aL.beginDelayedInit), aL.enabled = !0, a5() } return !0 } aU(); try { aG._externalInterfaceTest(!1), A(!0, aL.flashPollingInterval || (aL.useHighPerformance ? 10 : 50)), aL.debugMode || aG._disableDebug(), aL.enabled = !0, aL.html5Only || az.add(aI, "unload", a8) } catch (h) { return bd({ type: "JS_TO_FLASH_EXCEPTION", fatal: !0 }), aS(!0), a5(), !1 } a5(); az.remove(aI, "load", aL.beginDelayedInit); return !0 }; be = function () { if (aK) { return !1 } aK = !0; aJ(); I(); !au && aL.hasHTML5 && aL.setup({ useHTML5Audio: !0, preferFlash: !1 }); bE(); aL.html5.usingFlash = ab(); aB = aL.html5.usingFlash; bl(); !au && aB && aL.setup({ flashLoadTimeout: 1 }); aD.removeEventListener && aD.removeEventListener("DOMContentLoaded", be, !1); aU(); return !0 }; ak = function () { "complete" === aD.readyState && (be(), aD.detachEvent("onreadystatechange", ak)); return !0 }; bf = function () { ag = !0; az.remove(aI, "load", bf) }; ac(); az.add(aI, "focus", aV); az.add(aI, "load", bg); az.add(aI, "load", bf); aD.addEventListener ? aD.addEventListener("DOMContentLoaded", be, !1) : aD.attachEvent ? aD.attachEvent("onreadystatechange", ak) : bd({ type: "NO_DOM2_EVENTS", fatal: !0 }); "complete" === aD.readyState && setTimeout(be, 100) } var a = null; if ("undefined" === typeof SM2_DEFER || !SM2_DEFER) { a = new c } b.SoundManager = c; b.soundManager = a })(window); ; (function (c, b, a) { a(function () { a(".rating_action li").on("click", function () { var d = a(this); a.get("/flashcards/score-set", { set_id: d.parent().data("set_id"), score: d.data("score") }, function (e) { if (e.success) { a(".rating_action").empty().css({ width: e.score * 20 + "%" }) } else { if (e.redirect_url) { b.location = e.redirect_url + "?redirect_url=" + b.location.href } } }); return false }); a("a.report").on("click", function (d) { d.preventDefault(); var f = a(this); if (!f.is(".ico_flagged")) { a.get(f.data("link"), function (e) { if (e.success) { f.addClass("ico_flagged").removeClass("report").removeAttr("data-link").attr("title", e.title) } }) } }) }) } (document, window, jQuery)); ; (function (a) { var b = null; a.modal = function (e, d) { var c, f; this.$body = a("body"); this.options = a.extend({}, a.modal.defaults, d); if (e.is("a")) { f = e.attr("href"); if (/^#/.test(f)) { this.$elm = a(f); if (this.$elm.length !== 1) { return null } this.open() } else { this.$elm = a("<div>"); this.$body.append(this.$elm); c = function (h, g) { g.elm.remove() }; this.showSpinner(); e.trigger(a.modal.AJAX_SEND); a.get(f).done(function (g) { if (!b) { return } e.trigger(a.modal.AJAX_SUCCESS); b.$elm.empty().append(g).on(a.modal.CLOSE, c); b.hideSpinner(); b.open(); e.trigger(a.modal.AJAX_COMPLETE) }).fail(function () { e.trigger(a.modal.AJAX_FAIL); b.hideSpinner(); e.trigger(a.modal.AJAX_COMPLETE) }) } } else { this.$elm = e; this.open() } }; a.modal.prototype = { constructor: a.modal, open: function () { this.block(); this.show(); if (this.options.escapeClose) { a(document).on("keydown.modal", function (c) { if (c.which == 27) { a.modal.close() } }) } if (this.options.clickClose) { this.blocker.click(a.modal.close) } }, close: function () { this.unblock(); this.hide(); a(document).off("keydown.modal") }, block: function () { this.$elm.trigger(a.modal.BEFORE_BLOCK, [this._ctx()]); this.blocker = a('<div class="jquery-modal blocker"></div>').css({ top: 0, right: 0, bottom: 0, left: 0, width: "100%", height: "100%", position: "fixed", zIndex: this.options.zIndex, background: this.options.overlay, opacity: this.options.opacity }); this.$body.append(this.blocker); this.$elm.trigger(a.modal.BLOCK, [this._ctx()]) }, unblock: function () { this.blocker.remove() }, show: function () { this.$elm.trigger(a.modal.BEFORE_OPEN, [this._ctx()]); if (this.options.showClose) { this.closeButton = a('<a href="#close-modal" rel="modal:close" class="close-modal">' + this.options.closeText + "</a>"); this.$elm.append(this.closeButton) } this.$elm.addClass(this.options.modalClass + " current"); this.center(); this.$elm.show().trigger(a.modal.OPEN, [this._ctx()]) }, hide: function () { this.$elm.trigger(a.modal.BEFORE_CLOSE, [this._ctx()]); if (this.closeButton) { this.closeButton.remove() } this.$elm.removeClass("current").hide(); this.$elm.trigger(a.modal.CLOSE, [this._ctx()]) }, showSpinner: function () { if (!this.options.showSpinner) { return } this.spinner = this.spinner || a('<div class="' + this.options.modalClass + '-spinner"></div>').append(this.options.spinnerHtml); this.$body.append(this.spinner); this.spinner.show() }, hideSpinner: function () { if (this.spinner) { this.spinner.remove() } }, center: function () { this.$elm.css({ position: "fixed", top: "50%", left: "50%", marginTop: -(this.$elm.outerHeight() / 2), marginLeft: -(this.$elm.outerWidth() / 2), zIndex: this.options.zIndex + 1 }) }, _ctx: function () { return { elm: this.$elm, blocker: this.blocker, options: this.options} } }; a.modal.prototype.resize = a.modal.prototype.center; a.modal.close = function (c) { if (!b) { return } if (c) { c.preventDefault() } b.close(); b = null }; a.modal.resize = function () { if (!b) { return } b.resize() }; a.modal.defaults = { overlay: "#000", opacity: 0.75, zIndex: 998, escapeClose: true, clickClose: true, closeText: "Close", modalClass: "modal", spinnerHtml: null, showSpinner: true, showClose: true }; a.modal.BEFORE_BLOCK = "modal:before-block"; a.modal.BLOCK = "modal:block"; a.modal.BEFORE_OPEN = "modal:before-open"; a.modal.OPEN = "modal:open"; a.modal.BEFORE_CLOSE = "modal:before-close"; a.modal.CLOSE = "modal:close"; a.modal.AJAX_SEND = "modal:ajax:send"; a.modal.AJAX_SUCCESS = "modal:ajax:success"; a.modal.AJAX_FAIL = "modal:ajax:fail"; a.modal.AJAX_COMPLETE = "modal:ajax:complete"; a.fn.modal = function (c) { if (this.length === 1) { b = new a.modal(this, c) } return this }; a(document).on("click", 'a[rel="modal:close"]', a.modal.close); a(document).on("click", 'a[rel="modal:open"]', function (c) { c.preventDefault(); a(this).modal() }) })(jQuery); ; /*!
 * jQuery Cookie Plugin v1.4.0
 * https://github.com/carhartl/jquery-cookie
 *
 * Copyright 2013 Klaus Hartl
 * Released under the MIT license
 */
/*(function (a) { if (typeof define === "function" && define.amd) { define(["jquery"], a) } else { a(jQuery) } } (function (f) { var a = /\+/g; function d(i) { return b.raw ? i : encodeURIComponent(i) } function g(i) { return b.raw ? i : decodeURIComponent(i) } function h(i) { return d(b.json ? JSON.stringify(i) : String(i)) } function c(i) { if (i.indexOf('"') === 0) { i = i.slice(1, -1).replace(/\\"/g, '"').replace(/\\\\/g, "\\") } try { i = decodeURIComponent(i.replace(a, " ")) } catch (j) { return } try { return b.json ? JSON.parse(i) : i } catch (j) { } } function e(j, i) { var k = b.raw ? j : c(j); return f.isFunction(i) ? i(k) : k } var b = f.cookie = function (q, p, v) { if (p !== undefined && !f.isFunction(p)) { v = f.extend({}, b.defaults, v); if (typeof v.expires === "number") { var r = v.expires, u = v.expires = new Date(); u.setDate(u.getDate() + r) } return (document.cookie = [d(q), "=", h(p), v.expires ? "; expires=" + v.expires.toUTCString() : "", v.path ? "; path=" + v.path : "", v.domain ? "; domain=" + v.domain : "", v.secure ? "; secure" : ""].join("")) } var w = q ? undefined : {}; var s = document.cookie ? document.cookie.split("; ") : []; for (var o = 0, m = s.length; o < m; o++) { var n = s[o].split("="); var j = g(n.shift()); var k = n.join("="); if (q && q === j) { w = e(k, p); break } if (!q && (k = e(k)) !== undefined) { w[j] = k } } return w }; b.defaults = {}; f.removeCookie = function (j, i) { if (f.cookie(j) !== undefined) { f.cookie(j, "", f.extend({}, i, { expires: -1 })); return true } return false } })); ; (function (D, m, n) { var z = false; var d = false; var e = false; var E = false; var l = false; var x = false; var y = false; var g = false; var B; var q; var b; var a = false; var t; var j = "instructions"; var w; var i = false; var C; var v; var A = window.location.href; var o = A.indexOf("/#share-set/"); function s() { if (i) { clearTimeout(w); i = false; document.getElementById("med_rect_ad").contentDocument.location.reload(true); w = setTimeout(function () { k() }, 40000) } } function k() { i = true } w = setTimeout(function () { k() }, 40000); function p() { x = true; window.soundManager = new SoundManager(); soundManager.setup({ url: "/flash/", debugFlash: false, preferflash: false, debugMode: false }); soundManager.beginDelayedInit() } var h = function (Y) { var J = Y, I = 0, G = J.length, U = false, aa = false, N = false, ab = false, L = true, P = 0, O = Langs.lang_front, H = Langs.lang_back, F = n("#chbFrontFirst"), R = n("#chbBothSides"), Q = n("#frontCardSide"), V = n("#backCardSide"), T = n("#chbreadItToMe"), W = n("#alpha-order"), S = null; var Z = "front", ac = "back", K = "both_sides"; this.showInstructions = function () { n(".flashcardNav > *").hide(); n(".instructionsBox").show(); n(".sideName, .progress_bar, #txtFlip").hide() }; this.init = function () { j = "study"; I = q - 1; n(".flashcardNav > *").show(); n(".cardAnswerArea,.instructionsBox").hide(); n(".sideName, .progress_bar, #txtFlip").show(); if (J.length) { this.refreshView() } return this }; this.next = function () { if (!((I + 1) == B)) { ++I } else { I = (q - 1) } this.refreshView() }; this.previous = function () { if (!((I - 1) < (q - 1))) { --I } else { I = B - 1 } this.refreshView() }; this.getCurrentCard = function () { return I }; this.setCurrentCard = function (ad) { I = ad }; this.getTotalCards = function () { return G }; this.refresh = function () { X(); if (!x && (J[I]["audio_front"] !== null || J[I]["audio_back"] !== null)) { p() } if (soundManager) { soundManager.stopAll() } if (F.is(":checked")) { Q.show(); V.hide(); n("#txtFlip").show(); n(".sideName span").replaceWith("<span>" + n.stmode.translate("word_front") + "</span>"); L = true; S = Z; d = L; M(true); if (J[I]["audio_front"] !== null) { n("#playBtn div").show(); n("#playBtn2 div").hide(); l = true } else { n("#playBtn div, #playBtn2 div").hide(); l = false } } if (R.is(":checked")) { y = false; n(".cardContent").off("click.flip"); Q.show(); V.show(); n("#txtFlip").hide(); n(".sideName span").replaceWith("<span>" + n.stmode.translate("word_both") + "</span>"); L = false; S = K; d = L; M(false); if (J[I]["audio_front"] !== null) { n("#playBtn div").show(); l = true } else { n("#playBtn div").hide(); l = false } if (J[I]["audio_back"] !== null) { n("#playBtn2 div").show(); l = true } else { n("#playBtn2 div").hide(); l = false } } if (!R.is(":checked") && !F.is(":checked")) { Q.hide(); V.show(); n("#txtFlip").show(); n(".sideName span").replaceWith("<span>" + n.stmode.translate("word_back") + "</span>"); L = false; S = ac; d = L; M(true); if (J[I]["audio_back"] !== null) { n("#playBtn2 div").show(); n("#playBtn div").hide(); l = true } else { n("#playBtn2 div, #playBtn div").hide(); l = false } } if (W.is(":checked")) { if (U && !L) { J.sort(function (ae, ad) { if (ae.back.toLowerCase() < ad.back.toLowerCase()) { return -1 } if (ae.back.toLowerCase() > ad.back.toLowerCase()) { return 1 } return 0 }) } else { J.sort(function (ae, ad) { if (ae.front.toLowerCase() < ad.front.toLowerCase()) { return -1 } if (ae.front.toLowerCase() > ad.front.toLowerCase()) { return 1 } return 0 }) } } this.readItToMe() }; var X = function () { n("#playBtn div").removeClass("playing"); n("#playBtn2 div").removeClass("playing") }; var M = function (ad) { if (!U && ad) { U = true; n("#txtFlip, .cardContent").on("click.flip", function (ae) { var af = n(ae.target).parent().attr("id"); if (af !== "playBtn" && af !== "playBtn2") { if (n("#hintCardSide").is(":visible")) { return } X(); if (z) { c() } else { if (soundManager) { soundManager.stopAll() } if (R.is(":checked")) { n(".sideName span").replaceWith("<span>" + n.stmode.translate("word_back") + "</span>"); S = K; if (J[I]["audio_front"] !== null || J[I]["audio_back"] !== null) { l = true } else { l = false } if (J[I]["audio_front"] !== null) { n("#playBtn div").show() } else { n("#playBtn div").hide() } if (J[I]["audio_back"] !== null) { n("#playBtn2 div").show() } else { n("#playBtn2 div").hide() } } else { if (L == true) { S = ac; L = false; d = L; n(".sideName span").replaceWith("<span>" + n.stmode.translate("word_back") + "</span>"); if (J[I]["audio_back"] !== null) { n("#playBtn div").hide(); n("#playBtn2 div").show(); l = true } else { n("#playBtn div, #playBtn2 div").hide(); l = false } } else { L = true; S = Z; d = L; if (J[I]["audio_front"] !== null) { n("#playBtn div").show(); n("#playBtn2 div").hide(); l = true } else { n("#playBtn2 div,#playBtn div").hide(); l = false } n(".sideName span").replaceWith("<span>" + n.stmode.translate("word_front") + "</span>") } } Q.slideToggle(50, function () { ++P; n(D).triggerHandler("readItToMe") }); V.slideToggle(50, function () { ++P; n(D).triggerHandler("readItToMe") }) } } }) } if (!ad) { U = false; n("#txtFlip, .cardContent").off("click.flip") } }; this.refreshView = function () { var aj = B; b = B - (q - 1); var af = ((I + 1) - (q - 1)) / b * 100; n(".progress_bar span:last").html(((I + 1) - (q - 1)) + "<em>" + n.stmode.translate("word_of") + "</em>" + b); if (a) { a = false; if (I <= q) { I = Number(q - 1); n(".progress_bar span:last").html(1 + "<em>" + n.stmode.translate("word_of") + "</em>" + b); var af = 1 / b * 100 } if (I >= B) { I = Number(B - 1); n(".progress_bar span:last").html(b + "<em>" + n.stmode.translate("word_of") + "</em>" + b); af = 100 } } n(".progress_bar p span").width(af + "%"); if (j != "instructions") { X(); n("#hintCardSide").hide(); n("#frontCardSide p span").html(n.stmode.htmlescape(J[I]["front"]).nl2br()); n("#backCardSide p span").html(n.stmode.htmlescape(J[I]["back"]).nl2br()); if ((J[I]["hint"] != "" && J[I]["hint"] != null) || J[I]["srcHint"] != null) { e = true; n("#hintCardSide p span").html(n.stmode.htmlescape(J[I]["hint"]).nl2br()) } else { e = false } var ae = n("#backCardSide p img"); var ai = n("#frontCardSide p img"); var al = n("#hintCardSide p img"); if (J[I]["src"] != null) { var ad = J[I]["src"]; ae.removeAttr("width height"); ae.removeAttr("width height"); ae.parent().hide(); ae.attr("src", ad).on("load", function (am) { ae.parent().show(); ae.fadeIn(300) }) } else { ae.hide(); ae.parent().hide() } if (J[I]["srcFront"] != null) { var ah = J[I]["srcFront"]; ai.attr("src", "").hide(); ai.removeAttr("width height"); ai.parent().hide(); ai.attr("src", ah).on("load", function (am) { ai.parent().show(); ai.fadeIn(300) }) } else { ai.hide(); ai.parent().hide() } if (J[I]["srcHint"] != null) { var ak = J[I]["srcHint"]; al.attr("src", "").hide(); al.removeAttr("width height"); al.parent().hide(); al.attr("src", ak).on("load", function (am) { al.parent().show(); al.fadeIn(300) }) } else { al.hide(); al.parent().hide() } for (var ag = 0; ag < 2; ag++) { if (typeof J[I + ag] != "undefined" && J[I + ag]["src"] != null) { n(D.createElement("img")).removeAttr("width height"); n(D.createElement("img")).attr("src", J[I + ag]["src"]) } } for (var ag = 0; ag < 2; ag++) { if (typeof J[I + ag] != "undefined" && J[I + ag]["srcFront"] != null) { n(D.createElement("img")).removeAttr("width height"); n(D.createElement("img")).attr("src", J[I + ag]["srcFront"]) } } for (var ag = 0; ag < 2; ag++) { if (typeof J[I + ag] != "undefined" && J[I + ag]["srcHint"] != null) { n(D.createElement("img")).removeAttr("width height"); n(D.createElement("img")).attr("src", J[I + ag]["srcHint"]) } } this.refresh() } s() }; this.reverseOrder = function (ad) { if (n(ad).is(":checked") && !aa) { aa = true; J.reverse() } else { aa = false; J.reverse() } this.refreshView() }; this.alphaOrder = function (ad) { N = false; if (n(ad).is(":checked") && !ab) { ab = true; if (U && !L) { J.sort(function (af, ae) { if (af.back.toLowerCase() < ae.back.toLowerCase()) { return -1 } if (af.back.toLowerCase() > ae.back.toLowerCase()) { return 1 } return 0 }) } else { J.sort(function (af, ae) { if (af.front.toLowerCase() < ae.front.toLowerCase()) { return -1 } if (af.front.toLowerCase() > ae.front.toLowerCase()) { return 1 } return 0 }) } } else { ab = false; J.sort(function (af, ae) { return parseFloat(af.card_id) - parseFloat(ae.card_id) }) } this.refreshView() }; this.shuffle = function () { N = true; var af = ""; v = J; v = v.sort(function (ai, ah) { return parseFloat(ai.card_id) - parseFloat(ah.card_id) }); var ag = v.slice(q - 1, B).sort(function () { return 0.5 - Math.random() }); var ad = 0; for (var ae = q - 1; ae < B; ae++) { v[ae] = ag[ad]; ad++ } }; this.shuffleOrder = function (ag) { v = J; var ah = ""; v = v.sort(function (ak, aj) { return parseFloat(ak.card_id) - parseFloat(aj.card_id) }); for (var af = 0; af < v.length; af++) { ah += v[af]["front"] + " - " } if (n(ag).is(":checked") && !N) { N = true; var ae = ""; v = J; v = v.sort(function (ak, aj) { return parseFloat(ak.card_id) - parseFloat(aj.card_id) }); var ai = v.slice(q - 1, B).sort(function () { return 0.5 - Math.random() }); var ad = 0; for (var af = q - 1; af < B; af++) { v[af] = ai[ad]; ad++ } } else { N = false } this.refreshView() }; this.getFlipStatus = function () { return P }; this.setFlipStatus = function (ad) { P = ad }; this.readItToMe = function () { if (T.is(":checked")) { soundManager.stopAll(); var ae, ad, ag, af; ae = J[I]["front"]; ad = "front_" + J[I]["card_id"]; ag = J[I]["back"]; af = "back_" + J[I]["card_id"]; r(ae, ad, O); r(ag, af, H); if (R.is(":checked")) { f(ad + "_0", true); return } if (n("#frontCardSide").is(":visible")) { f(ad + "_0", false); return } else { f(af + "_0", false); return } } }; this.playUserAudio = function (ad) { soundManager.stopAll(); n("#playBtn2 div,#playBtn div").removeClass("playing"); switch (S) { case Z: if (J[I]["audio_front"] !== null) { var af = Z + "_" + J[I]["card_id"] + "_0"; soundManager.createSound({ id: af, url: J[I]["audio_front"], multiShot: true, multiShotEvents: true, onfinish: function () { n("#playBtn div").removeClass("playing") } }); soundManager.play(af) } break; case ac: if (J[I]["audio_back"] !== null) { var ae = ac + "_" + J[I]["card_id"] + "_0"; soundManager.createSound({ id: ae, url: J[I]["audio_back"], multiShot: true, multiShotEvents: true, onfinish: function () { n("#playBtn2 div").removeClass("playing") } }); soundManager.play(ae) } break; case K: if (ad == "playBtn") { if (J[I]["audio_front"] !== null) { var af = Z + "_" + J[I]["card_id"] + "_0"; soundManager.createSound({ id: af, url: J[I]["audio_front"], multiShot: true, multiShotEvents: true, onfinish: function () { n("#playBtn div").removeClass("playing") } }); soundManager.play(af) } } if (ad == "playBtn2") { if (J[I]["audio_back"] !== null) { var ae = ac + "_" + J[I]["card_id"] + "_0"; soundManager.createSound({ id: ae, url: J[I]["audio_back"], multiShot: true, multiShotEvents: true, onfinish: function () { n("#playBtn2 div").removeClass("playing") } }); soundManager.play(ae) } } break } } }; var f = function (F, G) { G = typeof G == "undefined" ? false : G; soundManager.play(F, { onfinish: function () { var M = this.id, L = M.lastIndexOf("_"), K = parseInt(M.substr(L + 1)), J = M.substr(0, L) + "_" + (K + 1), I = M.substr(0, M.indexOf("_")); if (soundManager.getSoundById(J) == null && G == true && I == "front") { var H = J.lastIndexOf("_"); J = J.substr(0, H) + "_" + 0; J = J.replace("front_", "back_") } f(J, G) } }) }; var r = function (K, F, J) { var G = new Array(""), H = 0, I = K.split(/(\.|!|,|-|\?|;|:| )/gi); do { if ((G[H].length + I[0].length) < 100) { G[H] += I[0]; I.shift() } else { G[++H] = "" } } while (I.length != 0); for (H = 0; H < G.length; H++) { soundManager.createSound({ id: F + "_" + H, url: "/services/text-to-speech?lang=" + J + "&text=" + encodeURIComponent(G[H]), multiShot: false }) } }; n(function () { var F = [n.stmode.translate("rotational_social_sharing1"), n.stmode.translate("rotational_social_sharing2"), n.stmode.translate("rotational_social_sharing3"), n.stmode.translate("rotational_social_sharing4"), n.stmode.translate("rotational_social_sharing5"), n.stmode.translate("rotational_social_sharing6")]; F.sort(function () { return 0.5 - Math.random() }); var G = 0; var J = true; n("#social_share").hover(function () { if (J) { n(".third-party-social").css({ left: 0 }, 0); n(".social-links").stop().fadeOut(0); J = false; n(this).stop().animate({ opacity: 1, height: 320 }, 200, function () { }) } }, function () { }); n("#social_share").fadeIn(1000, function () { I(); n(".social-links").delay(5000).fadeOut(400); n(this).delay(5000).animate({ height: 320 }, 400, function () { n(".third-party-social").css({ left: 0 }, 0) }) }); n("#social_share div p").fadeIn().html(F[0]); function I() { n("#social_share div p").delay(10000).fadeOut(1000, function () { n(this).fadeIn().html(H()); I() }) } function H() { if (G < F.length - 1) { G++ } else { G = 0 } return F[G] } }); function u(H, G, F) { n.ajax({ url: H, dataType: "jsonp", success: function (I) { n(F).html(I[G]) } }) } n(document).ready(function () { var F = n("#social_share").offset().top - parseFloat(n("#social_share").css("marginTop").replace(/auto/, 0)); n(window).scroll(function (I) { var J = n(this).scrollTop(); var G = n(".main-content").offset().top + n(".main-content").height() - n("#social_share").height(); var H = G - 450; if (J >= F) { if (J > G) { n("#social_share").addClass("fixed2"); n("#social_share").css("top", H); n("#social_share").removeClass("fixed") } else { n("#social_share").addClass("fixed"); n("#social_share").removeClass("fixed2"); n("#social_share").css("top", 0) } } else { n("#social_share").removeClass("fixed") } }) }); n(function () { if (n("#flashCardsListingTable").length > 0) { n(D).on("change", "#tablePagination_rowsPerPage", function () { n.cookie("rowsPerPage", n(this).val(), { expires: 365, path: "/" }) }); if (n.cookie("rowsPerPage")) { var I = n.cookie("rowsPerPage") } else { var I = 10 } n("#flashCardsListingTable").tablePagination({ currPage: 1, rowsPerPage: I }) } n("#modal_clicker").click(function (J) { J.preventDefault(); g = true; n("#shareBoxModal").modal({ showClose: false, escapeClose: false, clickClose: false }).each(function () { n(".jquery-modal, #close_modal").on("click", function () { g = false; n.modal.close() }); if (o == -1 && G != 1) { n("#signInBtn").on("click", function () { var T = "/mail/detect-user/"; var U = {}; var V = "check_login"; U.userState = "signin"; U.redirectURL = window.location.href + "/#share-set/"; M(T, U, V) }); n("#signUpModalBtn").on("click", function () { var T = "/mail/detect-user/"; var U = {}; var V = "check_login"; U.userState = "signup"; U.redirectURL = window.location.href + "/#share-set/"; M(T, U, V) }) } else { O() } function O() { var U = n("#setAccess").val(); var T = n("#setID").val(); var V = "/set/convert-set/"; if (U == "private") { n("#cancelShareSet").on("click", function () { g = false; n.modal.close() }); n("#makePublicBtn").on("click", function () { P(T, V) }) } else { R() } } function P(T, U) { n.ajax({ url: U, type: "POST", data: { setId: T }, success: function (V) { if (V.code == 1) { R() } } }) } function R() { K("SHARE_SET"); n("#share_set").submit(function () { return false }); n("#shareSendBtn").on("click", function () { var T = n("#friendEmailList").val(); N(T) }) } function K(T) { n("#modal_body").html(""); var U = ""; switch (T) { case "MAKE_PUBLIC": U = '<div class="modal_content set_public">'; U += "<p>" + n.stmode.translate("share_message_make_public_1") + "</p>"; U += "<p>" + n.stmode.translate("share_message_make_public_2") + "</p>"; U += '<div><button id="cancelShareSet" class="allRounded redBtn mediumBtn" type="button">' + n.stmode.translate("word_cancel") + "</button>"; U += '<button id="makePublicBtn" class="allRounded greenBtn mediumBtn" type="button">' + n.stmode.translate("share_make_public") + "</button></div></div>"; break; case "SHARE_SET": U = '<div class="modal_content share_page">'; U += "  <p><label>" + n.stmode.translate("share_label_send") + ":</label><br/>"; U += '<input class="allRounded txt whitebg emailTxt" id="friendEmailList" type="text" placeholder="' + n.stmode.translate("share_email_placeholder") + '" /></p>'; U += '<p class="userMessage error"></p>'; U += '<button id="shareSendBtn" class="allRounded greenBtn mediumBtn">' + n.stmode.translate("share_send_message") + "</button></p>"; U += '    <p class="disclaimer">' + n.stmode.translate("share_disclaimer") + "</p></div>"; break; case "CONFIRMATION": U = '<div class="modal_content confirmation">'; U += "<p>" + n.stmode.translate("share_confirmation") + "</p>"; U += '<p><button class="allRounded greenBtn mediumBtn">' + n.stmode.translate("link_done") + "</button></p></div>"; break; default: break } n(U).appendTo("#modal_body") } function L(T) { var U = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/; return U.test(T) } function Q(U, T) { T = n.trim((T == null) ? "" : T); var V = T.search("http://"); if (T.length == 0 || T.length == undefined) { return "" } if (V == -1) { if (T.substr(0, 2) == "//") { T = "http:" + T } else { T = U + T } } return T } function M(T, U, V) { n.ajax({ url: "/mail/detect-user/", type: "POST", data: U, success: function (W) { if (W.code == 1) { window.location.href = W.redirectUrl } } }) } function S(T, U, V) { n.ajax({ url: T, type: "POST", data: U, success: function () { K("CONFIRMATION"); n(".confirmation button").on("click", function () { g = false; n.modal.close() }); n(".modal").delay(1000).fadeOut(200, function () { g = false; n.modal.close() }) } }) } function N(au) { if (au != "") { var ao = au.split(","); var aw = []; var aj = []; C = []; for (var at = 0; at < ao.length; at++) { var ac = n.trim(ao[at]); var an = L(ac); if (an) { aw.push(ac) } else { aj.push(ac) } } var V = ""; if (aj.length > 0) { if (aj.length == 1) { V = aj[0] } else { for (var ap = 0; ap < aj.length; ap++) { if (ap < (Number(aj.length) - 1)) { V += aj[ap] + ", " } else { V += aj[ap] } } } n(".userMessage").show().html(V + " " + n.stmode.translate("error_email_check")) } else { n(".userMessage").hide(); var Z = n("tr:nth-child(1) .front_image"); var aA = n("tr:nth-child(1) .front_image").find("img").attr("src"); var aq = n("tr:nth-child(1) .front_text").html(); var al = n("tr:nth-child(1) .back_image"); var ae = n("tr:nth-child(1) .back_image").find("img").attr("src"); var X = n("tr:nth-child(1) .back_text").html(); var W = n("tr:nth-child(2) .front_image"); var ay = n("tr:nth-child(2) .front_image").find("img").attr("src"); var aa = n("tr:nth-child(2) .front_text").html(); var am = n("tr:nth-child(2) .back_image"); var ai = n("tr:nth-child(2) .back_image").find("img").attr("src"); var T = n("tr:nth-child(2) .back_text").html(); var ag = n("tr:nth-child(3) .front_image"); var ab = n("tr:nth-child(3) .front_image").find("img").attr("src"); var ah = n("tr:nth-child(3) .front_text").html(); var af = n("tr:nth-child(3) .back_image"); var Y = n("tr:nth-child(3) .back_image").find("img").attr("src"); var ar = n("tr:nth-child(3) .back_text").html(); var ax = {}; var ak = "share_set"; var U = "http://" + n("#urlLink").val(); var az = "/mail/share-set/"; ax.setId = n("#setID").val(); ax.setUrl = "http://" + n("#setURLLink").val(); ax.emailList = aw; ax.frontText01 = n.trim((aq == null) ? "" : aq); ax.backText01 = n.trim((X == null) ? "" : X); var av = ""; var ad = ""; av = Q(U, aA); ad = (aA != null) ? Z.find("img").attr("src", av) : ""; ax.frontImage01 = (Z.html() == null) ? "" : Z.html(); av = Q(U, ae); ad = (ae != null) ? al.find("img").attr("src", av) : ""; ax.backImage01 = (al.html() == null) ? "" : al.html(); ax.frontText02 = n.trim((aa == null) ? "" : aa); ax.backText02 = n.trim((T == null) ? "" : T); av = Q(U, ay); ad = (ay != null) ? W.find("img").attr("src", av) : ""; ax.frontImage02 = (W.html() == null) ? "" : W.html(); av = Q(U, ai); ad = (ai != null) ? am.find("img").attr("src", av) : ""; ax.backImage02 = (am.html() == null) ? "" : am.html(); ax.frontText03 = n.trim((ah == null) ? "" : ah); ax.backText03 = n.trim((ar == null) ? "" : ar); av = Q(U, ab); ad = (ab != null) ? ag.find("img").attr("src", av) : ""; ax.frontImage03 = (ag.html() == null) ? "" : ag.html(); av = Q(U, Y); ad = (Y != null) ? af.find("img").attr("src", av) : ""; ax.backImage03 = (af.html() == null) ? "" : af.html(); S(az, ax, ak) } } else { n(".userMessage").show().html(n.stmode.translate("error_enter_email_generic")) } } }) }); if (n(".enableAudio").is(":visible")) { if (!x) { p() } } n(D).on("click", ".enableAudio", function () { n(this).addClass("preview_playing"); var J = n(this); soundManager.createSound({ id: J.data("card_id") + "_0", url: J.data("audio"), multiShot: true, multiShotEvents: true, onfinish: function () { J.removeClass("preview_playing") } }); soundManager.stopAll(); soundManager.play(J.data("card_id") + "_0") }); if (Cards.length) { var H = new h(Cards); H.showInstructions(); t = Cards.length; if (t == 1) { n("#slider-range").slider({ range: true, min: 0, max: 1, values: [0, 1], slide: function (J, K) { n("#minAmount").val(K.values[0]); n("#maxAmount").val(K.values[1]); a = true; q = 1; B = 1 } }); n("#slider-range .ui-slider-handle").unbind("keydown"); n("#minAmount,#maxAmount").val(1); q = 1; B = 1; b = 1; n("#minAmount, #maxAmount").attr("disabled", "disabled"); n("#slider-range").slider("disable") } else { n("#slider-range").slider({ range: true, min: 1, max: H.getTotalCards(), values: [1, H.getTotalCards()], slide: function (J, K) { n("#minAmount").val(K.values[0]); n("#maxAmount").val(K.values[1]); a = true; q = n("#minAmount").val(); B = n("#maxAmount").val(); if (n("#shuffle-order").is(":checked")) { H.shuffle() } H.refreshView() } }); n("#slider-range .ui-slider-handle").unbind("keydown"); n("#minAmount").val(n("#slider-range").slider("values", 0)); n("#maxAmount").val(n("#slider-range").slider("values", 1)); q = n("#slider-range").slider("values", 0); B = n("#slider-range").slider("values", 1); b = B - (q - 1) } n(".ui-slider a:first").css({ "background-position": "4px -68px" }); n("#maxAmount, #minAmount").keydown(function (J) { if (J.keyCode == 46 || J.keyCode == 8 || J.keyCode == 9 || J.keyCode == 27 || J.keyCode == 13 || (J.keyCode == 65 && J.ctrlKey === true) || (J.keyCode >= 35 && J.keyCode <= 39)) { return } else { if (J.shiftKey || (J.keyCode < 48 || J.keyCode > 57) && (J.keyCode < 96 || J.keyCode > 105)) { J.preventDefault() } } }); n("#maxAmount, #minAmount").keyup(function (J) { if (n("#minAmount").val() == "") { } a = true; if (J.keyCode == 46 || J.keyCode == 8 || J.keyCode == 9 || J.keyCode == 27 || J.keyCode == 13 || (J.keyCode == 65 && J.ctrlKey === true) || (J.keyCode >= 35 && J.keyCode <= 39)) { return } else { if (J.shiftKey || (J.keyCode < 48 || J.keyCode > 57) && (J.keyCode < 96 || J.keyCode > 105)) { J.preventDefault() } if ((Number(n("#minAmount").val()) < 1) || (Number(n("#minAmount").val()) > Number(B))) { alert("Please enter a valid minimum amount within range") } else { q = n("#minAmount").val() } if ((Number(n("#maxAmount").val()) > t) || (Number(n("#maxAmount").val()) < Number(q))) { alert("Please enter a valid maximum amount within range") } else { B = n("#maxAmount").val(); n("#slider-range").slider("values", [q, B]); if (n("#shuffle-order").is(":checked")) { H.shuffle() } H.refreshView() } } }); var G = n("#userLoggedIn").val(); if (o != -1) { n("#modal_clicker").trigger("click") } n("#cardAnswerAreaNext").on("click", function () { H.next() }); n("#cardAnswerAreaPrev").on("click", function () { H.previous() }); n("#startBtn").on("click", function () { if (!E) { H.init(); E = true } }); n("#chbFrontFirst").on("change", function () { if (z) { c() } n("#chbBothSides").attr("checked", false); H.refresh() }); n("#chbBothSides").on("change", function () { if (z) { c() } n("#chbFrontFirst").attr("checked", false); H.refresh() }); n("#chbreversOrder").on("change", function () { if (z) { c() } H.reverseOrder(this) }); n("#shuffle-order").on("change", function () { if (z) { c() } n("#alpha-order").attr("checked", false); H.shuffleOrder(this) }); n("#alpha-order").on("change", function () { if (z) { c() } n("#shuffle-order").attr("checked", false); H.alphaOrder(this) }); n(D).on("change", "#chbreadItToMe", function () { H.readItToMe() }); n(D).on("readItToMe", function () { if (H.getFlipStatus() == 2) { H.setFlipStatus(0); H.readItToMe() } }); n(D).on("click", "#playBtn div, #playBtn2 div", function () { var J = n(this).parent().attr("id"); H.playUserAudio(J); n(this).addClass("playing") }) } var F = function () { n("#flashcardActions li input").each(function (J, L) { var K = n(L); if (K.is(":checked")) { K.siblings().hide().end().siblings(".hOn").show() } else { K.siblings().hide().end().siblings(".hOff").show() } }) }; F(); n(D).on("click", "#flashcardActions li", function (K) { var J = n(this).find("input[type=checkbox]"); if (J.is(":checked")) { J.attr("checked", false).trigger("change") } else { J.attr("checked", true).trigger("change") } F() }) }); function c() { if (z) { n("#hintCardSide").stop().hide(); if (l) { if (d) { n("#playBtn div").show(); n("#playBtn2 div").hide() } else { n("#playBtn div").hide(); n("#playBtn2 div").show() } if (n("#chbBothSides").is(":checked")) { n("#playBtn div, #playBtn2 div").show() } n("#playBtn div, #playBtn2 div").removeClass("playing") } if (d == true) { n("#frontCardSide").stop().fadeIn(); n("#backCardSide").stop().fadeOut(); n("#txtFlip").stop().fadeIn(); n(".sideName span").replaceWith("<span>" + n.stmode.translate("word_front") + "</span>") } else { if (n("#chbBothSides").is(":checked")) { n("#frontCardSide").stop().fadeIn(); n("#backCardSide").stop().fadeIn(); n(".sideName span").replaceWith("<span>" + n.stmode.translate("word_both") + "</span>"); n("#txtFlip").stop().hide() } else { n("#frontCardSide").stop().fadeOut(); n("#backCardSide").stop().fadeIn(); n("#txtFlip").stop().fadeIn(); n(".sideName span").replaceWith("<span>" + n.stmode.translate("word_back") + "</span>") } } } else { n("#hintCardSide").stop().fadeIn(); n("#txtFlip").stop().fadeOut(); n("#frontCardSide").stop().hide(); n("#backCardSide").stop().hide(); n("#playBtn div, #playBtn2 div").hide(); n("#playBtn div, #playBtn2 div").removeClass("playing"); if (soundManager) { soundManager.stopAll() } n(".sideName span").replaceWith("<span>" + n.stmode.translate("word_hint") + "</span>") } z = !z } n(D).on("keydown", function (G) { if (!g) { if (n("#query").is(":focus") || !E) { if (G.keyCode == 32 && !n("#query").is(":focus")) { G.preventDefault(); n("#startBtn").trigger("click") } return true } else { if (n("#minAmount, #maxAmount").is(":focus")) { } else { G.preventDefault(); switch (G.keyCode) { case 32: n("#startBtn").trigger("click"); return false; break; case 37: n("#cardAnswerAreaPrev").trigger("click"); return false; break; case 39: n("#cardAnswerAreaNext").trigger("click"); return false; break; case 38: case 40: if (d) { n("#frontCardSide").trigger("click") } else { n("#backCardSide").trigger("click") } return false; break; case 72: if (e) { c() } return false; break; case 80: if (n("#chbBothSides").is(":checked")) { if (y == false) { var F = n("#playBtn div") } else { var F = n("#playBtn2 div") } y = !y } else { if (d) { var F = n("#playBtn div") } else { var F = n("#playBtn2 div") } } if (F.is(":visible")) { F.trigger("click") } return false; break; default: return true; break } } } } }) } (document, window, jQuery)); (function () { var a = document.createElement("script"); a.type = "text/javascript"; a.async = true; a.src = "https://apis.google.com/js/plusone.js"; var b = document.getElementsByTagName("script")[0]; b.parentNode.insertBefore(a, b) })(); !function (e, a, f) { var c, b = e.getElementsByTagName(a)[0]; if (!e.getElementById(f)) { c = e.createElement(a); c.id = f; c.src = "https://platform.twitter.com/widgets.js"; b.parentNode.insertBefore(c, b) } } (document, "script", "twitter-wjs"); ; window.fbAsyncInit = function () { FB.init({ appId: $.stmode.tplVars.facebook.clientId, status: true, cookie: true, xfbml: true }) }; (function (f, b, a) { var e, g = "facebook-jssdk", c = f.getElementsByTagName("script")[0]; if (f.getElementById(g)) { return } e = f.createElement("script"); e.id = g; e.async = true; e.src = "//connect.facebook.net/" + b.language + "/all" + (a ? "/debug" : "") + ".js"; c.parentNode.insertBefore(e, c) } (document, $.stmode.tplVars.facebook, false));
*/
/// <reference path="jquery-1.7.2.js" />
var showingAns = false;
var numQuestions = 0;
var numCorrect = 0;


function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

function animateCard() {
    document.getElementById('spinner').classList.remove("spinAnimation");
    document.getElementById('spinner').offsetWidth = document.getElementById('spinner').offsetWidth;
    document.getElementById('spinner').classList.add("spinAnimation");
    $("#fldcardCol2").height($("#fldcardCol1").height());
}

function setCardAudio()
{
    //set audio to answer audio on flip
    var ansaudio = $('.wizard-step:visible > .frontCard').find('input.questionAudio[type="hidden"]').val();
    $('.amazingaudioplayer-source').attr("data-src", ansaudio);
    $('#amazingaudioplayer-1').find('audio').find('source').attr('src', ansaudio);
    $('#amazingaudioplayer-1').find('audio').trigger('pause');
    $('#amazingaudioplayer-1').find('audio').currentTime = 0; //prop("currentTime", 0);
}

$('#txtFlip').click(function () {

    if (!$('.cardAnswerArea').is(":visible")) {
        $('.wizard-step:visible > .frontCard').slideToggle();
        $('.wizard-step:visible > .backCard').slideToggle();
        $('.cardAnswerArea').toggle();
        $('.cssFlip').hide();

        animateCard();
        setTimeout(function () { $(".headerOptions").css("background-color", "#636363"); }, 250);
        setTimeout(function () { $("#card_name").css("color", "#F7F7F7"); }, 250);

        //set audio to answer audio on flip
        var ansaudio = $('.wizard-step:visible > .frontCard').find('input.answerAudio[type="hidden"]').val();
        $('.amazingaudioplayer-source').attr("data-src", ansaudio);
        $('#amazingaudioplayer-1').find('audio').find('source').attr('src', ansaudio);
        $('#amazingaudioplayer-1').find('audio').trigger('pause');
        //$('#amazingaudioplayer-1').find('audio').stopAudio();//prop("currentTime", 0);


        //$('#txtFlip').attr("disabled", true);

    }
    else {
        alert("Please indicate whether you got it right or not ?");
    }
});

$('#btnRightAns').click(function () {

    var cardid = $('.wizard-step:visible > .frontCard').find('input.classcardid[type="hidden"]').val();
    //var cardid = $('.wizard-step:visible > .frontCard').find('input[type="hidden"]').val();
    var sesid = $('#SessionId').val();
    var ccount = parseInt($('#ccount').val());  //all flash card count
    var totalcount = parseInt($('#totalcount').val());  //all flash card count

    var refillcount = parseInt($('#refillcount').val());  //all refill flash card count

    var fncount = parseInt($('#fncount').val());
    var actualfinishedcount = parseInt($('#finishedcount').val());

    var finishedcount = parseInt($('#finishedCards').val());



    var $step = $(".wizard-step:visible"); // get current step
    var data_yes = parseInt($step.attr("data-yes"));
    var data_no = parseInt($step.attr("data-no"));
    var data_inc = parseInt($step.attr("data-incl"));
    data_yes = data_yes + 1;
    //alert(data_inc);

    //if (data_inc == 0) {
    //    //update indicator
    //    var per = ((finishedcount + 1) * 25 / (totalcount)).toFixed(2); //each correct card is a 1/4.. 
    //    //alert(per);
    //    $("#perspan").css("width", per + '%');
    //    $("#perspan").text(per + '%');
    //}

    //$('#finishedCards').val(finishedcount + 1);



    if (data_inc == 0 && data_yes == 4) {  //save if this is part of our selection
        $('#finishedcount').val(actualfinishedcount + 1);
        $.ajax({
            type: "POST",
            data: { cid: cardid, sid: sesid, ans: true, done: data_yes, fin: actualfinishedcount+1 },
            dataType: "json",
            url: '/Flash/SaveCard/',
            success: function (data) {
                if (data.res == true) {

                    //$('#finishedCards').val(finishedcount + 1);
                    var per = ((actualfinishedcount + 1) * 100 / (totalcount)).toFixed(2); //each correct card is a 1/4.. 
                    //alert(per);
                    $("#perspan").css("width", per + '%');
                    $("#perspan").text(per + '%');

                }
                else {
                    alert('Error : Unable to Save session at this time ');
                }
            },
            error: function (data) {
                alert('Error : ');
            }

        });
    }

    $('.cardAnswerArea').toggle();
    $('#txtFlip').show();


    //update yes n nos
    $step.attr("data-yes", data_yes);
    $step.attr("data-no", data_no);
    var $laststep = $('.wizard-step.confirm');

    if (actualfinishedcount == totalcount) {
        var $step4 = $(".wizard-step:visible");
        $step4.hide();

        $step = $laststep.prev();
        $step.hide().next().fadeIn();
        //$laststep.fadeIn();
        //$step.hide();

        if ($step.next().hasClass("confirm")) { // is it confirmation?
            // show confirmation asynchronously

            $.post("/Flash/FinishedCards", $("form").serialize(), function (r) {
                // inject response in confirmation step
                $(".wizard-step.confirm").html(r);
            });

            $("#next-step").show();
            //$("#restart-step").show();
            $("#next-step").val('Done');
            $('.cssFlip').hide();
            $('.progress_bar').css("padding-bottom", "30px");
        }

        else if ($step.next().hasClass("confirm2")) { // is it confirmation?
            // show confirmation asynchronously

            $.post("/Flash/FinishedCards", $("form").serialize(), function (r) {
                // inject response in confirmation step
                $(".wizard-step.confirm").html(r);
            });

            $("#next-step").show();
            //$("#restart-step").show();
            $("#next-step").val('Done');
            $('.cssFlip').hide();
            $('.progress_bar').css("padding-bottom", "30px");
        }

        return;
    }
    else {

        $step.hide().next().fadeIn();  // show it and hide current step


        //if ($step.next().hasClass("confirm")) { // is it confirmation?
        //    // show confirmation asynchronously
        //    $.post("/Flash/FinishedCards", $("form").serialize(), function (r) {
        //        // inject response in confirmation step
        //        $(".wizard-step.confirm").html(r);
        //    });

        //    $("#next-step").show();
        //    $("#restart-step").show();
        //    $("#next-step").val('Done');
        //}

        //if ($step.next().hasClass("confirm2")) { // is it confirmation?
        //    // show confirmation asynchronously
        //    $.post("/Flash/FinishedCards", $("form").serialize(), function (r) {
        //        // inject response in confirmation step
        //        $(".wizard-step.confirm").html(r);
        //    });

        //    $("#next-step").show();
        //    $("#restart-step").show();
        //    $("#next-step").val('Done');


        //}

        if ( refillcount>0 && ccount<=8) {

            var $refill = $(".reFill > :first-child");


            // var $refill = $('.reFill').children().first(); // get refill step
            //$ref.$refill.appendTo();
            $refill.insertBefore($laststep);
            //append from refill if we short by one..
            ccount = ccount + 1;
            $('#ccount').val(ccount);
            refillcount = refillcount - 1;
            $('#refillcount').val(refillcount);
            //alert($laststep.context);
            //alert($refill.context);
        }

        var $step2 = $step.next().next();
        var $steplast = $step.next();

        if (data_yes == 4 && ccount > 3 && data_inc == 0) {
            //remove from the page
            $step.remove();
            ccount = ccount - 1;

            //if (true) {
            //    var $laststep = $('.wizard-step.confirm');
            //    var $refill = $(".reFill.wizard-step:first"); // get refill step
            //    //$ref.$refill.appendTo();
            //    $refill.insertBefore($laststep);
            //    //append from refill if we short by one..
            //    ccount = ccount + 1;
            //}
            $('#ccount').val(ccount);

            //advance progress
            //$('#finishedCards').val(finishedcount + 1);
            //var per = ((finishedcount + 1) * 100 / (ccount)).toFixed(2);
            // $("#perspan").css("width", per + '%');
            //$("#perspan").text(per + '%');
        }
        else if (ccount >= 8) {
            if (data_yes == 1) {
                $step2.after($step);
            }
            else if (data_yes == 2) {
                $step2.next().next().after($step);
            }
            else if (data_yes == 3) {
                $step2.next().next().next().next().after($step);
            }

        }
        else if (ccount >= 6 && ccount < 8) {
            if (data_yes == 1) {
                $step2.after($step);
            }
            else if (data_yes == 2) {
                $step2.next().next().after($step);
            }
            else if (data_yes == 3) {
                $step2.next().next().after($step);
            }
        }
        else if (ccount >= 4 && ccount < 6) {
            if (data_yes == 1) {
                $step2.after($step);
            }
            else if (data_yes == 2) {
                $step2.next().after($step);
            }
            else if (data_yes == 3) {
                $step2.next().after($step);
            }
        }

            //else if (ccount >2 && ccount < 4) {
            //    if (data_yes == 1) {
            //        $step2.after($step);
            //    }
            //    else if (data_yes == 2) {
            //        $step2.after($step);
            //    }
            //    else if (data_yes == 3) {
            //        $step2.after($step);
            //    }
            //}
        else if (ccount == 3) {

            var id1 = $('#fncount').attr("data-id1");
            var id2 = $('#fncount').attr("data-id2");
            var id3 = $('#fncount').attr("data-id3");

            if (data_yes >= 4) {
                $step2.after($step);
                //fncount = fncount + 1;
                if (id1 == "0") {
                    $('#fncount').val(fncount + 1);
                    $('#fncount').attr("data-id1", cardid);
                }
                else if (id2 == "0" && cardid != id1) {
                    $('#fncount').val(fncount + 1);
                    $('#fncount').attr("data-id2", cardid);
                }
                else if (id3 == "0" && (cardid != id1 && cardid != id2)) {
                    $('#fncount').val(fncount + 1);
                    $('#fncount').attr("data-id3", cardid);
                }
            }

            else {
                $step2.after($step);
            }



            if (parseInt($('#fncount').val()) >= 3) {
                var $step4 = $(".wizard-step:visible");
                $step4.hide();
                $step.hide().next().fadeIn();
                if ($step.next().hasClass("confirm")) { // is it confirmation?
                    // show confirmation asynchronously

                    $.post("/Flash/FinishedCards", $("form").serialize(), function (r) {
                        // inject response in confirmation step
                        $(".wizard-step.confirm").html(r);
                    });

                    $("#next-step").show();
                    //$("#restart-step").show();
                    $("#next-step").val('Done');
                    $('.cssFlip').hide();
                    $('.progress_bar').css("padding-bottom", "30px");
                }

                else if ($step.next().hasClass("confirm2")) { // is it confirmation?
                    // show confirmation asynchronously

                    $.post("/Flash/FinishedCards", $("form").serialize(), function (r) {
                        // inject response in confirmation step
                        $(".wizard-step.confirm").html(r);
                    });

                    $("#next-step").show();
                    //$("#restart-step").show();
                    $("#next-step").val('Done');
                    $('.cssFlip').hide();
                    $('.progress_bar').css("padding-bottom", "30px");
                }

            }

        }
    }

    $('.wizard-step:visible > #frontCardSide').show();
    $('.wizard-step:visible > #backCardSide').hide();

    //$("#back-step").show();   // recall to show backStep button
    $('.cardAnswerArea').hide();



    /*if ($step.next().hasClass("wizard-step")) { // is there any next step?
        $('.wizard-step:visible > #frontCardSide').show();
        $('.wizard-step:visible > #backCardSide').hide();
        $('.cardAnswerArea').hide();
        $step.hide().next().fadeIn();  // show it and hide current step
        //$("#back-step").show();   // recall to show backStep button

    }*/


    $(".headerOptions").css("background-color", "#F7F7F7");
    $("#card_name").css("color", "#636363");
    setCardAudio();
});

$('#btnWrongAns').click(function () {

    var cardid = $('.wizard-step:visible > .frontCard').find('input.classcardid[type="hidden"]').val();
    var sesid = $('#SessionId').val();
    /*$.ajax({
        type: "POST",
        data: { cid: cardid, sid: sesid, ans: false },
        dataType: "json",
        url: '/Flash/SaveCard/',
        success: function (data) {
            if (data.res == true) {

            }
            else {
                alert('Error : Unable to Save session at this time ');
            }
        },
        error: function (data) {
            alert('Error : ');
        }

    });*/

    $('.cardAnswerArea').toggle();

    var $step = $(".wizard-step:visible"); // get current step
    var data_yes = parseInt($step.attr("data-yes"));
    var data_no = parseInt($step.attr("data-no"));
    data_no = data_no + 1;

    //update nos
    $step.attr("data-no", data_no);
    $step.attr("data-yes", 0);

    $step.hide().next().fadeIn();  // show it and hide current step

    if ($step.next().hasClass("confirm")) { // is it confirmation?
        // show confirmation asynchronously
        $.post("/Flash/FinishedCards", $("form").serialize(), function (r) {
            // inject response in confirmation step
            $(".wizard-step.confirm").html(r);
        });

        $("#next-step").show();
        //$("#restart-step").show();
        $("#next-step").val('Done');
        $(".progress_bar").css("padding-bottom", "30px");

    }

    if ($step.next().hasClass("confirm2")) {
        // is it confirmation?
        // show confirmation asynchronously
        $.post("/Flash/FinishedCards", $("form").serialize(), function (r) {
            // inject response in confirmation step
            $(".wizard-step.confirm").html(r);
        });

        $("#next-step").show();
        //$("#restart-step").show();
        $("#next-step").val('Done');
        $(".progress_bar").css("padding-bottom", "30px");

    }

    var $step2 = $step.next();

    $step2.after($step);


    $('.wizard-step:visible > #frontCardSide').show();
    $('.wizard-step:visible > #backCardSide').hide();

    $('.cardAnswerArea').hide();
    $('#txtFlip').show();



    /*if ($step.next().hasClass("wizard-step")) { // is there any next step?
        $('.wizard-step:visible > #frontCardSide').show();
        $('.wizard-step:visible > #backCardSide').hide();
        $('.cardAnswerArea').hide();
        $step.hide().next().fadeIn();  // show it and hide current step
        //$("#back-step").show();   // recall to show backStep button

    }*/

    $(".headerOptions").css("background-color", "#F7F7F7");
    $("#card_name").css("color", "#636363");
    setCardAudio();
});

$('#restart-step2').click(function () {

    var cid = getUrlVars()["cid"];
    //var sid = getUrlVars()["sid"];
    var sub = getUrlVars()["sub"];

    if (cid == "")
        window.location.href = "/Flash";
    else
        window.location.href = "/Flash/ReviseCard?cid=" + cid + "&sub=" + sub;;
});

$('#restart-step').click(function () {

    //var cardid = $('.wizard-step:visible > .frontCard').find('input[type="hidden"]').val();
    var sesid = $('#SessionId').val();
    var cid = getUrlVars()["cid"];
    var sub = getUrlVars()["sub"];

    window.location.href = "/Flash/ReviseCard?sid=" + sesid + "&cid=" + cid + "&rp=1";
});

$('#next-step3').click(function () {

    window.location.href = "/Flash/Topics";
});

//AskMe later
$('#btnAskLater').click(function (e) {
    e.preventDefault();
    var rptcombo = $("#comboRepeatCard").data("kendoComboBox");
    var sesid = $('#SessionId').val();
    var cardid = $('.wizard-step:visible > .frontCard').find('input.classcardid[type="hidden"]').val();
    //alert(rptcombo.value() );
    if (rptcombo.value() !="")
    {
        if (rptcombo.value() == 0) 
        {

            var $step = $(".wizard-step:visible"); // get current step
            $step.hide().next().fadeIn();
            $step.remove();

        }
        alert(rptcombo.value());
        $.ajax({
            type: "POST",
            data: { SessionId: sesid, cardid: cardid, askafter: rptcombo.value() },
            dataType: "json",
            url: '/Flash/AskMeLater/',
            success: function (data) {

                if (data.res == true) {
                    //success action
                    $("#comboRepeatCard").data("kendoComboBox").value(null);
                    //var $step = $(".wizard-step:visible"); // get current step
                    //$step.hide().next().fadeIn();
                    ////alert(rptcombo.value());
                    //$step.remove();
                }
                else {
                    alert('An Error : Please try again..');
                    $("#comboRepeatCard").data("kendoComboBox").value(null);
                }
            },

        });
    }
});

//Toggle background music..
$('#bgmusic-toggle-switch').on('switch-change', function (e, data) {
    var stats = $('#bgmusic-toggle-switch').bootstrapSwitch('status');
    if(stats == true) 
    {
        $(".ctlbgmusic").trigger('play');
    }
    else {
        $(".ctlbgmusic").trigger('pause');
        $(".ctlbgmusic").prop("currentTime", 0);
    }
    //var $el = $(data.el)
    // , value = data.value;
    //console.log(e, $el, value);    
});


//Submission for navigation
$(function () {

    $(".wizard-step:first").fadeIn(); // show first step

    $("#next-step").val('Continue');
    $("#restart-step").hide();
    $("#next-step").hide();
    $("#back-step").hide()
    // attach backStep button handler
    // hide on first step
    $("#back-step").hide().click(function () {
        var $step = $(".wizard-step:visible"); // get current step
        $('.wizard-step:visible > #frontCardSide').show();
        $('.wizard-step:visible > #backCardSide').hide();
        $('.cardAnswerArea').hide();
        if ($step.prev().hasClass("wizard-step")) { // is there any previous step?
            $step.hide().prev().fadeIn();  // show it and hide current step



            $("#next-step").val('Continue');
            // disable backstep button?
            if (!$step.prev().prev().hasClass("wizard-step")) {
                $("#back-step").hide();
            }

        }
    });

    $("#restart-step").hide().click(function () {
        var $step = $(".wizard-step:visible"); // get current step
        $('.wizard-step:visible > #frontCardSide').show();
        $('.wizard-step:visible > #backCardSide').hide();
        $('.cardAnswerArea').hide();
        if ($step.prev().hasClass("wizard-step")) { // is there any previous step?
            $step.hide().prev().fadeIn();  // show it and hide current step



            $("#next-step").val('Continue');
            // disable backstep button?
            if (!$step.prev().prev().hasClass("wizard-step")) {
                $("#back-step").hide();
            }

        }
    });
    // attach nextStep button handler       
    $("#next-step").click(function () {
        ///TODO: check if the user flipped the card as well 
        if ($('.cardAnswerArea').is(":visible")) {
            confirm("Did you Get this right or not ?");
        }
        else {
            var $step = $(".wizard-step:visible"); // get current step
            $('.wizard-step:visible > #frontCardSide').show();
            $('.wizard-step:visible > #backCardSide').hide();
            $('.cardAnswerArea').hide();

            /*var validator = $("form").validate(); // obtain validator
            var anyError = false;
            $step.find("input").each(function () {
                if (!validator.element(this)) { // validate every input element inside this step
                    anyError = true;
                }
    
            });
            
            if (anyError)
                return false; // exit if any error found
           */



            if ($step.next().hasClass("confirm")) { // is it confirmation?
                // show confirmation asynchronously
                $.post("/Flash/FinishedCards", $("form").serialize(), function (r) {
                    // inject response in confirmation step
                    $(".wizard-step.confirm").html(r);
                });
                $("#next-step").val('Done');
                $(".progress_bar").css("padding-bottom", "30px");

            }

            if ($step.next().hasClass("confirm2")) { // is it confirmation?
                // show confirmation asynchronously
                $.post("/Flash/FinishedCards", $("form").serialize(), function (r) {
                    // inject response in confirmation step
                    $(".wizard-step.confirm").html(r);
                });

                $("#next-step").val('Done');
                $(".progress_bar").css("padding-bottom", "30px");


            }

            if ($step.next().hasClass("wizard-step")) { // is there any next step?
                $('.wizard-step:visible > #frontCardSide').show();
                $('.wizard-step:visible > #backCardSide').hide();
                $('.cardAnswerArea').hide();
                $step.hide().next().fadeIn();  // show it and hide current step
                $("#back-step").show();   // recall to show backStep button

            }

            else { // this is last step, submit form
                //$("#next-step").hide();
                //$("form").submit();
            }
        }

    });

    setCardAudio();

});

function reFill(catid, sesid, nncards) {

    $.ajax({
        type: "POST",
        data: { cid: catid, sid: sesid},
        dataType: "json",
        url: '/Flash/SaveCard/',
        success: function (data) {
            if (data.res == true) {
                if (data_yes <= 4) {
                    //$('#finishedCards').val(finishedcount + 1);
                    var per = ((finishedcount + 1) * 25 / (ccount * 4)).toFixed(2); //each correct card is a 1/4.. 
                    //alert(per);
                    $("#perspan").css("width", per + '%');
                    $("#perspan").text(per + '%');
                }
            }
            else {
                alert('Error : Unable to Save session at this time ');
            }
        },
        error: function (data) {
            alert('Error : ');
        }

    });
}